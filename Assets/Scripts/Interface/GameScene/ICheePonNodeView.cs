using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;

namespace YarLiong.View
{
    public interface ICheePonNodeView
    {
        void SetListener(ICheePonNodeListener listener);

        void SetNode(INode node);
    }
}