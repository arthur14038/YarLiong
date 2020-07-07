using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.View;
using YarLiong.Model;

public class CheePonView : AbstractView, ICheePonView
{
    [SerializeField]
    Button m_EscapeButton;
    [SerializeField]
    Button m_GomokuButton;

    ICheePonListener mCheePonListener = null;

    public override IEnumerator Init()
    {
        m_EscapeButton.onClick.AddListener(() => { mCheePonListener.OnClickEscape(ViewPage.CheePon); });
        m_GomokuButton.onClick.AddListener(() => { mCheePonListener.OnClickGame(CheePonGameType.Gomoku); });
        yield return null;
    }

    public void SetListener(ICheePonListener listener)
    {
        mCheePonListener = listener;
    }
}
