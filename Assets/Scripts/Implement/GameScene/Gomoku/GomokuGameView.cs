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
    CheePon mCheePonData;
    List<GomokuNodeView> mAllNodeView;

    public override IEnumerator Init()
    {
        m_GomokuNodeView.gameObject.SetActive(false);
        mAllNodeView = new List<GomokuNodeView>();
        yield return null;
    }

    public void SetCheePon(CheePon cheePonData, ICheePonNodeListener cheePonNodeListener)
    {
        mCheePonData = cheePonData;
        var allNodes = mCheePonData.AllNodes;
        for (int i = 0; i < allNodes.Length; ++i)
        {
            var nodeView = Instantiate(m_GomokuNodeView, m_GridLayoutGroup.transform);
            mAllNodeView.Add(nodeView);
            nodeView.SetNode(allNodes[i]);
            nodeView.SetListener(cheePonNodeListener);
            nodeView.gameObject.SetActive(true);
        }
    }
}
