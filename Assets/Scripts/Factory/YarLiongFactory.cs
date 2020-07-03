using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Model;
using YarLiong.View;

public class YarLiongFactory
{
    static LoadingView loadingView = null;
    public static ILoadingView GetLoadingView()
    {
        if (loadingView == null)
        {
            var prefab = Resources.Load<GameObject>("Prefabs/LoadingCanvas");
            var viewObj = GameObject.Instantiate(prefab);
            loadingView = viewObj.GetComponent<LoadingView>();
        }

        return loadingView;
    }

    static MainGameModel mainGameModel = null;
    public static IMainGameModel MainGameModel {
        get
        {
            if (mainGameModel == null)
                mainGameModel = new MainGameModel();
            return mainGameModel;
        }
    }
}
