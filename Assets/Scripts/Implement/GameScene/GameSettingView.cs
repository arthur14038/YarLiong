﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.View;

public class GameSettingView : AbstractView, IGameSettingView
{
    [SerializeField]
    RectTransform m_StartViewRoot = null;
    [SerializeField]
    RectTransform m_EndViewRoot = null;
    [SerializeField]
    Button m_StartButton = null;
    [SerializeField]
    Button m_FinishButton = null;
    [SerializeField]
    Button m_AgainButton = null;
    [SerializeField]
    Text m_EndingMsgText = null;

    IGameSettingListener mGameSettingListener;

    public override IEnumerator Init()
    {
        m_StartViewRoot.gameObject.SetActive(false);
        m_EndViewRoot.gameObject.SetActive(false);

        m_StartButton.onClick.AddListener(() => { mGameSettingListener?.OnClickStart(); });
        m_FinishButton.onClick.AddListener(() => { mGameSettingListener?.OnClickFinish(); });
        m_AgainButton.onClick.AddListener(() => { mGameSettingListener?.OnClickAgain(); });

        yield return null;
    }

    public void SetListener(IGameSettingListener listener)
    {
        mGameSettingListener = listener;
    }

    public void ShowGameEndView(string endingMsg)
    {
        m_StartViewRoot.gameObject.SetActive(false);
        m_EndViewRoot.gameObject.SetActive(true);

        m_EndingMsgText.text = endingMsg;
    }

    public void ShowGameStartView()
    {
        m_StartViewRoot.gameObject.SetActive(true);
        m_EndViewRoot.gameObject.SetActive(false);
    }
}
