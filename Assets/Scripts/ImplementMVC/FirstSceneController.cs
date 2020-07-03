using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

public class FirstSceneController : MonoBehaviour, IController
{
    void Awake()
    {
        MainGameLogic.Instance.RegisterSceneController(this);
    }

    public IEnumerator Init()
    {
        yield return null;
        Debug.Log("FirstSceneController Init complete");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
