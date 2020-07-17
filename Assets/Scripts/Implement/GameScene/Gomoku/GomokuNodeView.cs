using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class GomokuNodeView : MonoBehaviour, ICheePonNodeView, IPointerClickHandler
{
    [SerializeField]
    Image m_ImageUp;
    [SerializeField]
    Image m_ImageDown;
    [SerializeField]
    Image m_ImageRight;
    [SerializeField]
    Image m_ImageLeft;
    [SerializeField]
    Image m_ImageChess;

    ICheePonNodeListener mCheePonNodeListener;
    GomokuNode mNodeData;

    public void OnPointerClick(PointerEventData eventData)
    {
        mCheePonNodeListener?.OnClickNode(mNodeData.X, mNodeData.Y);
    }

    public void SetListener(ICheePonNodeListener listener)
    {
        mCheePonNodeListener = listener;
    }

    public void SetNode(INode node)
    {
        mNodeData = node as GomokuNode;
        m_ImageUp.enabled = mNodeData.ThisNodeFlags.HasFlag(GomokuNodeFlags.Up);
        m_ImageDown.enabled = mNodeData.ThisNodeFlags.HasFlag(GomokuNodeFlags.Down);
        m_ImageRight.enabled = mNodeData.ThisNodeFlags.HasFlag(GomokuNodeFlags.Right);
        m_ImageLeft.enabled = mNodeData.ThisNodeFlags.HasFlag(GomokuNodeFlags.Left);

        m_ImageChess.enabled = mNodeData.CurrentGomokuNodeState != GomokuNodeState.Empty;
        m_ImageChess.color = mNodeData.CurrentGomokuNodeState == GomokuNodeState.Black ? Color.black : Color.white;
    }
}
