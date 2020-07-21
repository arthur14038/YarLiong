using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.View;

public class SnakeLogic : IGameController, IGameBackListener
{
    ISnakeGameView mSnakeGameView;
    IGameEndListener mGameEndListener;

    public IEnumerator Init()
    {
        throw new System.NotImplementedException();
    }

    public void OnClickGameBack()
    {
        mGameEndListener.OnGameQuit();
    }

    public void SetGameEndListener(IGameEndListener gameEndListener)
    {
        mGameEndListener = gameEndListener;
    }

    public void StartGame()
    {
        throw new System.NotImplementedException();
    }
}
