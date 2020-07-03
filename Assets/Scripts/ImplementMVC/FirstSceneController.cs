using System.Collections;
using UnityEngine;
using YarLiong.Controller;

public class FirstSceneController : AbstractSceneController
{
    public override IEnumerator Init()
    {
        yield return new WaitForSeconds(0.5f);

        MainGameLogic.Instance.LoadScene(SceneName.MainScene);
    }
}
