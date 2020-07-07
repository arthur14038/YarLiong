using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

public class GameSceneController : AbstractSceneController
{
    

    public override IEnumerator Init()
    {
        Debug.LogFormat("GameSceneController Init CurrentCheePonGameType: {0}", YarLiongFactory.CheePonGameModel.CurrentCheePonGameType);
        yield return null;
    }
}
