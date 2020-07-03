using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface IScrollView : IView
    {
        void SetListener(IScrollViewListener scrollViewListener);

        void Show(float value);
    }
}

