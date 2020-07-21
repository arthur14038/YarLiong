using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

public class GomokuGameView : AbstractView, ICheePonGameView
{
    [SerializeField]
    Button m_BackButton;
    [SerializeField]
    GridLayoutGroup m_GridLayoutGroup;
    [SerializeField]
    GomokuNodeView m_GomokuNodeView;
    [SerializeField]
    Image m_ImageCurrentRound;
    [SerializeField]
    RectTransform m_RoundRoot;

    GomokuCheePon mCheePonData;
    GomokuNodeView[,] mAllNodeView;
    IGameBackListener mGameBackListener;

    public void SetListener(IGameBackListener listener)
    {
        mGameBackListener = listener;
    }

    public override IEnumerator Init()
    {
        m_GomokuNodeView.gameObject.SetActive(false);
        m_RoundRoot.gameObject.SetActive(false);
        m_BackButton.onClick.AddListener(() => { mGameBackListener?.OnClickGameBack(); });
        yield return null;
    }

    public void SetCheePon(ICheePon cheePonData, ICheePonNodeListener cheePonNodeListener)
    {
        mCheePonData = cheePonData as GomokuCheePon;
        var allNodes = mCheePonData.AllNodes;

        if(mAllNodeView == null)
            mAllNodeView = new GomokuNodeView[allNodes.GetLength(0), allNodes.GetLength(1)];

        for (int j = 0; j < allNodes.GetLength(1); ++j)
            for (int i = 0; i < allNodes.GetLength(0); ++i)
            {
                if(mAllNodeView[i, j] == null)
                {
                    var nodeView = Instantiate(m_GomokuNodeView, m_GridLayoutGroup.transform);
                    mAllNodeView[i, j] = nodeView;
                }
                mAllNodeView[i, j].SetNode(allNodes[i, j]);
                mAllNodeView[i, j].SetListener(cheePonNodeListener);
                mAllNodeView[i, j].gameObject.SetActive(true);
            }
    }

    public void SetRound(CheePonRound round)
    {
        m_ImageCurrentRound.color = round == CheePonRound.Black ? Color.black : Color.white;
        m_RoundRoot.gameObject.SetActive(true);
    }

    public void UpdateNodeData(INode nodeData)
    {
        mAllNodeView[nodeData.X, nodeData.Y].SetNode(nodeData);
    }
}
