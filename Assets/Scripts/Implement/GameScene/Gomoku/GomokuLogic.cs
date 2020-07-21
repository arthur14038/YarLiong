using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class GomokuLogic : ICheePonController, ICheePonNodeListener
{
    ICheePonGameView mCheePonGameView = null;
    GomokuCheePon mGomokuCheePon = null;
    CheePonRound mCurrentRound;
    IGameEndListener mGameEndListener;

    public IEnumerator Init()
    {
        mGomokuCheePon = new GomokuCheePon(15, 15);
        yield return null;
    }

    public void OnClickNode(int x, int y)
    {
        var node = mGomokuCheePon.AllNodes[x, y] as GomokuNode;
        if(node.CurrentGomokuNodeState == GomokuNodeState.Empty)
        {
            node.CurrentGomokuNodeState = mCurrentRound == CheePonRound.Black ? GomokuNodeState.Black : GomokuNodeState.White;
            mCheePonGameView.UpdateNodeData(node);

            CheckVictory(x, y);
        }
    }

    public void SetGameEndListener(IGameEndListener gameEndListener)
    {
        mGameEndListener = gameEndListener;
    }

    public void SetView(ICheePonGameView view)
    {
        mCheePonGameView = view;
    }

    public void StartGame()
    {
        mCurrentRound = CheePonRound.Black;

        mGomokuCheePon.ClearCheePon();
        mCheePonGameView.SetCheePon(mGomokuCheePon, this);

        mCheePonGameView.SetRound(mCurrentRound);
        mCheePonGameView.Show();
    }

    void CheckVictory(int x, int y)
    {
        var node = mGomokuCheePon.AllNodes[x, y] as GomokuNode;

        var checkColor = node.CurrentGomokuNodeState;
        int connectCount = 1;
        //檢查橫
        var rightSideNodes = mGomokuCheePon.GetRightSideNodes(x, y, 4);
        for(int i = 0; i < rightSideNodes.Length; ++i)
        {
            if (rightSideNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        var leftSideNodes = mGomokuCheePon.GetLeftSideNodes(x, y, 4);
        for (int i = 0; i < leftSideNodes.Length; ++i)
        {
            if (leftSideNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        if (connectCount >= 5)
        {
            ThisRoundWin();
            return;
        }
        else
            connectCount = 1;

        //檢查縱
        var upSideNodes = mGomokuCheePon.GetUpSideNodes(x, y, 4);
        for (int i = 0; i < upSideNodes.Length; ++i)
        {
            if (upSideNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        var downSideNodes = mGomokuCheePon.GetDownSideNodes(x, y, 4);
        for (int i = 0; i < downSideNodes.Length; ++i)
        {
            if (downSideNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        if (connectCount >= 5)
        {
            ThisRoundWin();
            return;
        }
        else
            connectCount = 1;

        //檢查斜向
        var rightDownObliqueNodes = mGomokuCheePon.GetRightDownObliqueNodes(x, y, 4);
        for (int i = 0; i < rightDownObliqueNodes.Length; ++i)
        {
            if (rightDownObliqueNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        var leftUpObliqueNodes = mGomokuCheePon.GetLeftUpObliqueNodes(x, y, 4);
        for (int i = 0; i < leftUpObliqueNodes.Length; ++i)
        {
            if (leftUpObliqueNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        if (connectCount >= 5)
        {
            ThisRoundWin();
            return;
        }
        else
            connectCount = 1;

        //檢查斜向
        var rightUpObliqueNodes = mGomokuCheePon.GetRightUpObliqueNodes(x, y, 4);
        for (int i = 0; i < rightUpObliqueNodes.Length; ++i)
        {
            if (rightUpObliqueNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        var leftDownObliqueNodes = mGomokuCheePon.GetLeftDownObliqueNodes(x, y, 4);
        for (int i = 0; i < leftDownObliqueNodes.Length; ++i)
        {
            if (leftDownObliqueNodes[i].CurrentGomokuNodeState == checkColor)
                connectCount++;
            else
                break;
        }
        if (connectCount >= 5)
        {
            ThisRoundWin();
            return;
        }
        else
            NextRound();
    }

    void NextRound()
    {
        mCurrentRound = mCurrentRound == CheePonRound.Black ? CheePonRound.White : CheePonRound.Black;
        mCheePonGameView.SetRound(mCurrentRound);
    }

    void ThisRoundWin()
    {
        mGameEndListener.OnGameEnd(string.Format("{0} Win!", mCurrentRound));
    }
}