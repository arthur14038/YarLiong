using System.Collections;
using YarLiong.Controller;
using YarLiong.View;
using UnityEngine;
using YarLiong.Model;

public class MainSceneController : AbstractSceneController, IMainSceneListener, ICheePonListener, IGaoZhiListener, ILuDouGaoListener
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

        mGaoZhiView = YarLiongFactory.GetGaoZhiView();
        mGaoZhiView.SetListener(this);
        if (mGaoZhiView != null)
            yield return StartCoroutine(mGaoZhiView.Init());

        mLuDouGaoView = YarLiongFactory.GetLuDouGaoView();
        mLuDouGaoView.SetListener(this);
        if (mLuDouGaoView != null)
            yield return StartCoroutine(mLuDouGaoView.Init());

        mGaoZhiView?.Hide();
        mCheePonView?.Hide();
        mLuDouGaoView?.Hide();
        mMainSceneView?.Show();

        yield return null;
    }

    public void OnClickEscape(ViewPage currentViewPage)
    {
        switch(currentViewPage)
        {
            case ViewPage.CheePon:
                mCheePonView?.Hide();
                mMainSceneView?.Show();
                break;
            case ViewPage.GaoZhi:
                mGaoZhiView?.Hide();
                mMainSceneView?.Show();
                break;
            case ViewPage.LuDouGao:
                mLuDouGaoView?.Hide();
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

    public void OnClickGame(CheePonGameType gameType)
    {
        YarLiongFactory.CheePonGameModel.CurrentCheePonGameType = gameType;
        MainGameLogic.Instance.LoadScene(SceneName.GameScene);
    }
}
