using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public enum SceneName
{
    FirstScene,
    MainScene,
}
public class MainGameLogic : SingletonMonoBehavior<MainGameLogic>
{
    ILoadingView mLoadingView = null;
    IController mSceneController = null;
    IMainGameModel mModel = null;

    public void RegisterSceneController(IController controller)
    {
        mSceneController = controller;
        Debug.LogFormat("MainGameLogic RegisterSceneController: {0}", controller.GetType().ToString());
    }

    public void LoadScene(SceneName sceneName)
    {
        Debug.LogFormat("MainGameLogic LoadScene: {0}", sceneName);
        mSceneController = null;
        StartCoroutine(LoadNextScene(sceneName.ToString()));
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        if (mLoadingView != null)
            yield return StartCoroutine(mLoadingView.Show(mModel.GetLoadingTips()));

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);

        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            yield return new WaitForEndOfFrame();
        }

        // Allow the activation of the scene again.
        op.allowSceneActivation = true;

        while (!op.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        if (mSceneController != null)
        {
            yield return StartCoroutine(mSceneController.Init());
        }

        if (mLoadingView != null)
            yield return StartCoroutine(mLoadingView.Hide());
    }

    IEnumerator Start()
    {
        DontDestroyOnLoad(this.gameObject);
        mLoadingView = YarLiongFactory.GetLoadingView();
        mModel = YarLiongFactory.MainGameModel;

        if(mLoadingView != null)
            yield return StartCoroutine(mLoadingView.Init());

        if(mSceneController != null)
        {
            yield return StartCoroutine(mSceneController.Init());
        }
    }
}
