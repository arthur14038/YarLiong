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

    public IEnumerator Init()
    {
        mGomokuCheePon = new GomokuCheePon(15, 15);
        yield return null;
    }

    public void OnClickNode(int x, int y)
    {
        Debug.LogFormat("OnClickNode x: {0}, y: {1}", x, y);
    }

    public void SetView(ICheePonGameView view)
    {
        mCheePonGameView = view;
        mCheePonGameView.SetCheePon(mGomokuCheePon, this);
        mCheePonGameView.Show();
    }
}