using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class GomokuLogic : ICheePonController, ICheePonNodeListener
{
    enum Round
    {
        White,
        Black,
    }

    ICheePonGameView mCheePonGameView = null;
    GomokuCheePon mGomokuCheePon = null;
    Round mCurrentRound;

    public IEnumerator Init()
    {
        mGomokuCheePon = new GomokuCheePon(15, 15);
        mCurrentRound = Round.Black;
        yield return null;
    }

    public void OnClickNode(int x, int y)
    {
        var node = mGomokuCheePon.GetCertainNode(x, y) as GomokuNode;
        if(node.CurrentGomokuNodeState == GomokuNodeState.Empty)
        {
            Debug.LogFormat("OnClickNode x: {0}, y: {1}, before CurrentGomokuNodeState: {2}", x, y, node.CurrentGomokuNodeState);
            node.CurrentGomokuNodeState = mCurrentRound == Round.Black ? GomokuNodeState.Black : GomokuNodeState.White;
            mCheePonGameView.UpdateNodeData(node);
            mCurrentRound = mCurrentRound == Round.Black ? Round.White : Round.Black;
            Debug.LogFormat("OnClickNode x: {0}, y: {1}, after CurrentGomokuNodeState: {2}", x, y, node.CurrentGomokuNodeState);
        }
    }

    public void SetView(ICheePonGameView view)
    {
        mCheePonGameView = view;
        mCheePonGameView.SetCheePon(mGomokuCheePon, this);
        mCheePonGameView.Show();
    }
}