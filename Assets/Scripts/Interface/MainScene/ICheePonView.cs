using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface ICheePonView : IView
    {
        void SetListener(ICheePonListener listener);
    }
}
