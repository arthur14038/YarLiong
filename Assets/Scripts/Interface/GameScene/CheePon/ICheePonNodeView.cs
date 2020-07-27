using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface ICheePonNodeView : INodeView
    {
        void SetListener(ICheePonNodeListener listener);
    }
}