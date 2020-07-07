using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface IGaoZhiView : IView
    {
        void SetListener(IGaoZhiListener listener);
    }
}
