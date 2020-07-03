using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.View;

public class MainGameLogic : SingletonMonoBehavior<MainGameLogic>
{
    enum Scene
    {
        FirstScene,
        MainScene,
    }

    ILoadingView mLoadingView = null;
    IController mSceneController = null;

    public void RegisterSceneController(IController controller)
    {
        mSceneController = controller;
    }

    //public IEnumerator LoadScene(Scene scene)
    //{

    //}

    private IEnumerator Start()
    {
        DontDestroyOnLoad(this.gameObject);
        mLoadingView = YarLiongFactory.GetLoadingView();

        mLoadingView.Init();

        if(mSceneController != null)
        {
            yield return StartCoroutine(mSceneController.Init());
        }
    }

}
