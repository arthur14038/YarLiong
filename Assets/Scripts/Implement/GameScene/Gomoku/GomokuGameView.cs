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

    GomokuCheePon mCheePonData;
    GomokuNodeView[,] mAllNodeView;

    public override IEnumerator Init()
    {
        m_GomokuNodeView.gameObject.SetActive(false);
        yield return null;
    }

    public void SetCheePon(ICheePon cheePonData, ICheePonNodeListener cheePonNodeListener)
    {
        mCheePonData = cheePonData as GomokuCheePon;
        var allNodes = mCheePonData.AllNodes;
        mAllNodeView = new GomokuNodeView[allNodes.GetLength(0), allNodes.GetLength(1)];
        for (int j = 0; j < allNodes.GetLength(1); ++j)
            for (int i = 0; i < allNodes.GetLength(0); ++i)
            {
                var nodeView = Instantiate(m_GomokuNodeView, m_GridLayoutGroup.transform);
                nodeView.SetNode(allNodes[i, j]);
                nodeView.SetListener(cheePonNodeListener);
                nodeView.gameObject.SetActive(true);
                mAllNodeView[i, j] = nodeView;
            }
    }

    public void SetRound(CheePonRound round)
    {
        m_ImageCurrentRound.color = round == CheePonRound.Black ? Color.black : Color.white;
    }

    public void UpdateNodeData(INode nodeData)
    {
        mAllNodeView[nodeData.X, nodeData.Y].SetNode(nodeData);
    }
}
