using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class GaoZhiView : AbstractView, IGaoZhiView
{
    [SerializeField]
    Button m_EscapeButton = null;
    [SerializeField]
    Button m_SnakeButton;

    IGaoZhiListener mGaoZhiListener = null;

    public override IEnumerator Init()
    {
        m_EscapeButton.onClick.AddListener(() => { mGaoZhiListener.OnClickEscape(ViewPage.GaoZhi); });
        m_SnakeButton.onClick.AddListener(() => { mGaoZhiListener.OnClickGame(GaoZhiGameType.Snake); });
        yield return null;
    }

    public void SetListener(IGaoZhiListener listener)
    {
        mGaoZhiListener = listener;
    }
}
