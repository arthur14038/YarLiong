using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;
using static YarLiong.Controller.ICheePonController;

public class GomokuLogic : ICheePonController, ICheePonNodeListener
{
    ICheePonGameView mCheePonGameView = null;
    GomokuCheePon mGomokuCheePon = null;
    CheePonRound mCurrentRound;

    public IEnumerator Init()
    {
        mGomokuCheePon = new GomokuCheePon(15, 15);
        mCurrentRound = CheePonRound.Black;
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

    public void SetView(ICheePonGameView view)
    {
        mCheePonGameView = view;
        mCheePonGameView.SetCheePon(mGomokuCheePon, this);
        mCheePonGameView.SetRound(mCurrentRound);
        mCheePonGameView.Show();
    }

    void CheckVictory(int x, int y)
    {
        var node = mGomokuCheePon.AllNodes[x, y] as GomokuNode;
        Debug.LogFormat("CheckVictory x: {0}, y: {1}, CurrentGomokuNodeState: {2}, mCurrentRound: {3}", 
            x, y, node.CurrentGomokuNodeState, mCurrentRound);

        var checkColor = node.CurrentGomokuNodeState;
        int connectCount = 1;
        //檢查橫


        NextRound();
    }

    void NextRound()
    {
        mCurrentRound = mCurrentRound == CheePonRound.Black ? CheePonRound.White : CheePonRound.Black;
        mCheePonGameView.SetRound(mCurrentRound);
    }
}