﻿using System.Collections;
using YarLiong.Controller;
using YarLiong.View;
using UnityEngine;

public class MainSceneController : AbstractSceneController, IMainSceneListener, ICheePonListener
{
    IMainSceneView mMainSceneView = null;
    ICheePonView mCheePonView = null;
    IGaoZhiView mGaoZhiView = null;
    ILuDouGaoView mLuDouGaoView = null;

    public override IEnumerator Init()
    {
        mMainSceneView = YarLiongFactory.GetMainSceneView();
        mMainSceneView.SetListener(this);
        if (mMainSceneView != null)
            yield return StartCoroutine(mMainSceneView.Init());

        mCheePonView = YarLiongFactory.GetCheePonView();
        mCheePonView.SetListener(this);
        if (mCheePonView != null)
            yield return StartCoroutine(mCheePonView.Init());

        mCheePonView?.Hide();
        mMainSceneView?.Show();
    }

    public void OnClickEscape(ViewPage currentViewPage)
    {
        switch(currentViewPage)
        {
            case ViewPage.CheePon:
                mCheePonView?.Hide();
                mMainSceneView?.Show();
                break;
        }
    }

    public void OnClickCheePon()
    {
        mMainSceneView?.Hide();
        mCheePonView?.Show();
    }

    public void OnClickGaoZhi()
    {
        mMainSceneView?.Hide();
        mGaoZhiView?.Show();
    }

    public void OnClickLuDouGao()
    {
        mMainSceneView?.Hide();
        mLuDouGaoView?.Show();
    }
}