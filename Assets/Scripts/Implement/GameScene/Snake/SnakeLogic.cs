using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class SnakeLogic : IGameController, IGameBackListener, IKeyboardListener
{
    enum SnakeMoveDirection
    {
        Up,
        Down,
        Right,
        Left,
    }

    ISnakeGameView mSnakeGameView;
    IGameEndListener mGameEndListener;

    SnakeMoveDirection mCurrentSnakeMoveDirection = SnakeMoveDirection.Right;

    SnakeGound mSnakeGound = null;
    SnakeNode mApplePosition;
    Queue<SnakeNode> mSnakeBodies;
    SnakeNode mSnakeHead;
    bool mGameStart = false;
    float mLastMoveTime = 0f;
    float mMoveDuration = 0.3f;

    public IEnumerator Init()
    {
        UserInputManager.Instance.RegisterKeyboardListener(this);

        mSnakeGameView = YarLiongFactory.GetGameView(GameType.Snake) as ISnakeGameView;
        mSnakeGameView.SetListener(this);

        mSnakeGound = new SnakeGound(17, 15);
        mSnakeGameView.SetGround(mSnakeGound);

        yield return mSnakeGameView.Init();

        mSnakeBodies = new Queue<SnakeNode>();
        mSnakeBodies.Enqueue(new SnakeNode(1, 7));
        mSnakeBodies.Enqueue(new SnakeNode(2, 7));
        mSnakeBodies.Enqueue(new SnakeNode(3, 7));
        mSnakeHead = new SnakeNode(4, 7);
        mSnakeBodies.Enqueue(mSnakeHead);

        mApplePosition = new SnakeNode(12, 7);

        mSnakeGameView.SetSnake(mSnakeBodies.ToArray());
        mSnakeGameView.SetApple(mApplePosition);
    }

    public void OnDestroy()
    {
        UserInputManager.Instance.UnregisterKeyboardListener(this);
    }

    public void OnClickGameBack()
    {
        mGameEndListener.OnGameQuit();
    }

    public void OnHorizontalClick(bool right)
    {
        switch(mCurrentSnakeMoveDirection)
        {
            case SnakeMoveDirection.Down:
            case SnakeMoveDirection.Up:
                mCurrentSnakeMoveDirection = right ? SnakeMoveDirection.Right : SnakeMoveDirection.Left;
                break;
        }
    }

    public void OnVerticalClick(bool up)
    {
        switch (mCurrentSnakeMoveDirection)
        {
            case SnakeMoveDirection.Right:
            case SnakeMoveDirection.Left:
                mCurrentSnakeMoveDirection = up ? SnakeMoveDirection.Up : SnakeMoveDirection.Down;
                break;
        }
    }

    public void SetGameEndListener(IGameEndListener gameEndListener)
    {
        mGameEndListener = gameEndListener;
    }

    public void StartGame()
    {
        mGameStart = true;
        mLastMoveTime = Time.time;
    }

    public void Update()
    {
        if(mGameStart)
        {
            if(Time.time - mLastMoveTime > mMoveDuration)
            {
                Move();
            }
        }
    }

    void Move()
    {
        mLastMoveTime = Time.time;

        int x, y;
        if(CheckMove(out x, out y))
        {
            var newHead = new SnakeNode(x, y);
            mSnakeBodies.Enqueue(newHead);
            mSnakeHead = newHead;
            if(x == mApplePosition.X && y == mApplePosition.Y)
            {
                mApplePosition = GetApple();
                mSnakeGameView.SetApple(mApplePosition);
            }
            else
            {
                var emptyNode = mSnakeBodies.Dequeue();
                mSnakeGameView.EmptyNode(emptyNode);
            }

            mSnakeGameView.SetSnake(mSnakeBodies.ToArray());
        }
        else
        {
            mGameEndListener.OnGameEnd(string.Format("Snake Length: {0}", mSnakeBodies.Count));
        }
    }

    bool CheckMove(out int x, out int y)
    {
        x = mSnakeHead.X;
        y = mSnakeHead.Y;

        switch(mCurrentSnakeMoveDirection)
        {
            case SnakeMoveDirection.Down:
                y++;
                break;
            case SnakeMoveDirection.Up:
                y--;
                break;
            case SnakeMoveDirection.Right:
                x++;
                break;
            case SnakeMoveDirection.Left:
                x--;
                break;
        }

        if (x >= mSnakeGound.Width || x < 0)
            return false;
        if (y >= mSnakeGound.Height || y < 0)
            return false;

        foreach (SnakeNode node in mSnakeBodies)
        {
            if (node.X == x && node.Y == y)
                return false;
        }

        return true;
    }

    SnakeNode GetApple()
    {
        int x = Random.Range(0, mSnakeGound.Width);
        int y = Random.Range(0, mSnakeGound.Height);

        foreach (SnakeNode node in mSnakeBodies)
        {
            if (node.X == x && node.Y == y)
                return GetApple();
        }

        return new SnakeNode(x, y);
    }
}
