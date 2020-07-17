using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;

namespace YarLiong.View
{
    public interface ICheePonGameView: IView
    {
        void SetCheePon(ICheePon cheePonData, ICheePonNodeListener cheePonNodeListener);

        void UpdateNodeData(INode nodeData);

        void SetRound(CheePonRound round);
    }
}