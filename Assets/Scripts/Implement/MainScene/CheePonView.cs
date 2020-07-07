using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.View;

public class CheePonView : AbstractView, ICheePonView
{
    [SerializeField]
    Button m_EscapeButton = null;
    ICheePonListener mCheePonListener = null;

    public override IEnumerator Init()
    {
        m_EscapeButton.onClick.AddListener(() => { mCheePonListener.OnClickEscape(ViewPage.CheePon); });
        yield return null;
    }

    public void SetListener(ICheePonListener listener)
    {
        mCheePonListener = listener;
    }
}
