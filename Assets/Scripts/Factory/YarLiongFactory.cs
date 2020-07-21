using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
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

    public static IMainSceneView GetMainSceneView()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/MainSceneCanvas");
        var viewObj = GameObject.Instantiate(prefab);
        return viewObj.GetComponent<MainSceneView>();
    }

    public static ICheePonView GetCheePonView()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/CheePonCanvas");
        var viewObj = GameObject.Instantiate(prefab);
        return viewObj.GetComponent<CheePonView>();
    }

    public static IGaoZhiView GetGaoZhiView()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/GaoZhiCanvas");
        var viewObj = GameObject.Instantiate(prefab);
        return viewObj.GetComponent<GaoZhiView>();
    }

    public static ILuDouGaoView GetLuDouGaoView()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/LuDouGaoCanvas");
        var viewObj = GameObject.Instantiate(prefab);
        return viewObj.GetComponent<LuDouGaoView>();
    }

    public static ICheePonGameView GetCheePonGameView(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.Gomoku:
                var prefab = Resources.Load<GameObject>("Prefabs/CheePonGameCanvas");
                var viewObj = GameObject.Instantiate(prefab);
                return viewObj.GetComponent<GomokuGameView>();
            default:
                return null;
        }
    }

    public static IGameSettingView GetGameSettingView()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/GameSettingCanvas");
        var viewObj = GameObject.Instantiate(prefab);
        return viewObj.GetComponent<GameSettingView>();
    }

    public static IGameController GetGameController(GameType gameType)
    {
        switch (gameType)
        {
            case GameType.Gomoku:
                return new GomokuLogic();
            default:
                return null;
        }
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