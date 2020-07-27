using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class SnakeLogic : IGameController, IGameBackListener, IKeyboardListener
{
    ISnakeGameView mSnakeGameView;
    IGameEndListener mGameEndListener;

    public IEnumerator Init()
    {
        UserInputManager.Instance.RegisterKeyboardListener(this);

        mSnakeGameView = YarLiongFactory.GetGameView(GameType.Snake) as ISnakeGameView;
        mSnakeGameView.SetListener(this);
        yield return mSnakeGameView.Init();

        //17*15
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
        throw new System.NotImplementedException();
    }

    public void OnVerticalClick(bool up)
    {
        throw new System.NotImplementedException();
    }

    public void SetGameEndListener(IGameEndListener gameEndListener)
    {
        mGameEndListener = gameEndListener;
    }

    public void StartGame()
    {
        throw new System.NotImplementedException();
    }
}
