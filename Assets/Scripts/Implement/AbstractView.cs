using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.View;

public abstract class AbstractView : MonoBehaviour, IView
{
    [SerializeField]
    protected Canvas m_ViewCanvas;
    [SerializeField]
    protected CanvasGroup m_ViewCanvasGroup;

    public abstract IEnumerator Init();

    public virtual void Show()
    {
        m_ViewCanvas.enabled = true;
        m_ViewCanvasGroup.alpha = 1;
    }

    public virtual void Hide()
    {
        m_ViewCanvas.enabled = false;
        m_ViewCanvasGroup.alpha = 0;
    }

    public void Destroy()
    {
    }
}
