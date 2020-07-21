using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.View;

public class GameSceneController : AbstractSceneController, IGameSettingListener, IGameEndListener
{
    IGameSettingView mGameSettingView;
    IGameController mGameController;

    public override IEnumerator Init()
    {
        var gameType = YarLiongFactory.MainGameModel.CurrentGameType;
        mGameController = YarLiongFactory.GetGameController(gameType);
        mGameController.SetGameEndListener(this);
        yield return StartCoroutine(mGameController.Init());

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

    public void OnClickStart()
    {
        mGameController.StartGame();
        mGameSettingView.Hide();
    }

    public void OnGameEnd(string msg)
    {
        mGameSettingView.Show();
        mGameSettingView.ShowGameEndView(msg);
    }

    public void OnGameQuit()
    {
        MainGameLogic.Instance.LoadScene(SceneName.MainScene);
    }
}
