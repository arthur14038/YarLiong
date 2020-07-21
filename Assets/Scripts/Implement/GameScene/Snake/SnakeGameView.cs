using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.View;

public class SnakeGameView : AbstractView, ISnakeGameView
{
    [SerializeField]
    Button m_BackButton = null;
    [SerializeField]
    GridLayoutGroup m_GridLayoutGroup = null;

    IGameBackListener mGameBackListener;

    public override IEnumerator Init()
    {
        m_BackButton.onClick.AddListener(() => { mGameBackListener?.OnClickGameBack(); });
        yield return null;
    }

    public void SetListener(IGameBackListener listener)
    {
        mGameBackListener = listener;
    }
}
