using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

public class GameSceneController : AbstractSceneController
{
    public override IEnumerator Init()
    {
        var gameType = YarLiongFactory.CheePonGameModel.CurrentCheePonGameType;
        var gameView = YarLiongFactory.GetCheePonGameView(gameType);
        var gameController = YarLiongFactory.GetCheePonController(gameType);
        yield return StartCoroutine(gameView.Init());
        yield return StartCoroutine(gameController.Init());
        gameController.SetView(gameView);
    }
}
