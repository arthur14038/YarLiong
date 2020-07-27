using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class SnakeGameView : AbstractView, ISnakeGameView
{
    [SerializeField]
    Button m_BackButton = null;
    [SerializeField]
    GridLayoutGroup m_GridLayoutGroup = null;
    [SerializeField]
    SnakeGroundNodeView m_SnakeGroundNodeView = null;

    IGameBackListener mGameBackListener;
    ISnakeGround mSnakeGround;

    SnakeGroundNodeView[,] mAllNodeView;

    public override IEnumerator Init()
    {
        m_BackButton.onClick.AddListener(() => { mGameBackListener?.OnClickGameBack(); });
        m_SnakeGroundNodeView.gameObject.SetActive(false);
        yield return null;

        var allNodes = mSnakeGround.AllNodes;

        if (mAllNodeView == null)
            mAllNodeView = new SnakeGroundNodeView[allNodes.GetLength(0), allNodes.GetLength(1)];

        for (int j = 0; j < allNodes.GetLength(1); ++j)
            for (int i = 0; i < allNodes.GetLength(0); ++i)
            {
                var nodeView = Instantiate(m_SnakeGroundNodeView, m_GridLayoutGroup.transform);
                nodeView.SetNode(allNodes[i, j]);
                nodeView.name = string.Format("Node({0}, {1})", i, j);
                nodeView.gameObject.SetActive(true);

                mAllNodeView[i, j] = nodeView;
            }
    }

    public void SetGround(ISnakeGround snakeGround)
    {
        mSnakeGround = snakeGround;

        m_GridLayoutGroup.cellSize = new Vector2(900f/snakeGround.Width, 900f / snakeGround.Width);
    }

    public void SetSnake(INode[] snakeBodies)
    {
        for(int i = 0; i < snakeBodies.Length; ++i)
        {
            mAllNodeView[snakeBodies[i].X, snakeBodies[i].Y].SetNodeState(SnakeNodeState.Body);
        }
    }

    public void SetApple(INode applePosition)
    {
        mAllNodeView[applePosition.X, applePosition.Y].SetNodeState( SnakeNodeState.Apple);
    }

    public void SetListener(IGameBackListener listener)
    {
        mGameBackListener = listener;
    }

    public void EmptyNode(INode emptyPosition)
    {
        mAllNodeView[emptyPosition.X, emptyPosition.Y].SetNodeState(SnakeNodeState.Empty);
    }
}
