using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.View;

public class MainSceneView : AbstractView, IMainSceneView
{
    IMainSceneListener mMainSceneListener = null;
    [SerializeField]
    Button m_CheePonBotton;
    [SerializeField]
    Button m_GaoZhiBotton;
    [SerializeField]
    Button m_LuDouGaoBotton;

    public override IEnumerator Init()
    {
        yield return null;

        m_CheePonBotton.onClick.AddListener(() => { mMainSceneListener?.OnClickCheePon(); });
        m_GaoZhiBotton.onClick.AddListener(() => { mMainSceneListener?.OnClickGaoZhi(); });
        m_LuDouGaoBotton.onClick.AddListener(() => { mMainSceneListener?.OnClickLuDouGao(); });
    }

    public void SetListener(IMainSceneListener listener)
    {
        mMainSceneListener = listener;
    }
}
