using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Model;
using YarLiong.View;

public class YarLiongFactory
{
    public static ILoadingView GetLoadingView()
    {
        throw new NotImplementedException();
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
