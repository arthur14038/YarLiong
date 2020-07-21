using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.View;

public class GameSceneController : AbstractSceneController, IGameSettingListener, IGameEndListener, IGameBackListener
{
    IGameSettingView mGameSettingView;
    ICheePonController mCheePonController;

    public override IEnumerator Init()
    {
        var gameType = YarLiongFactory.CheePonGameModel.CurrentCheePonGameType;
        var gameView = YarLiongFactory.GetCheePonGameView(gameType);
        mCheePonController = YarLiongFactory.GetCheePonController(gameType);
        mCheePonController.SetGameEndListener(this);
        gameView.SetListener(this);
        yield return StartCoroutine(gameView.Init());
        yield return StartCoroutine(mCheePonController.Init());
        mCheePonController.SetView(gameView);

        mGameSettingView = YarLiongFactory.GetGameSettingView();
        mGameSettingView.SetListener(this);
        yield return StartCoroutine(mGameSettingView.Init());
        mGameSettingView.Show();
        mGameSettingView.ShowGameStartView();
    }

    public void OnClickAgain()
    {
        mGameSettingView.ShowGameStartView();
    }

    public void OnClickFinish()
    {
        MainGameLogic.Instance.LoadScene(SceneName.MainScene);
    }

    public void OnClickGameBack()
    {
        MainGameLogic.Instance.LoadScene(SceneName.MainScene);
    }

    public void OnClickStart()
    {
        mCheePonController.StartGame();
        mGameSettingView.Hide();
    }

    public void OnGameEnd(string msg)
    {
        mGameSettingView.Show();
        mGameSettingView.ShowGameEndView(msg);
    }
}
