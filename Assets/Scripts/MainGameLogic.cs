using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

public class MainGameLogic : SingletonMonoBehavior<MainGameLogic>
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    public void RegisterSceneController(IController controller)
    {

    }
}
