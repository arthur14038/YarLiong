using System.Collections;
using YarLiong.Controller;
using YarLiong.View;
using UnityEngine;

public class MainSceneController : AbstractSceneController, IMainSceneListener
{
    IMainSceneView mMainSceneView = null;

    public override IEnumerator Init()
    {
        mMainSceneView = YarLiongFactory.GetMainSceneView();
        mMainSceneView.SetListener(this);

        if (mMainSceneView != null)
            yield return StartCoroutine(mMainSceneView.Init());

        mMainSceneView.Show();
    }

    public void OnClickCheePon()
    {
        Debug.Log("OnClickCheePon");
    }

    public void OnClickGaoZhi()
    {
        Debug.Log("OnClickGaoZhi");
    }

    public void OnClickLuDouGao()
    {
        Debug.Log("OnClickLuDouGao");
    }
}
