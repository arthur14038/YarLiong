using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface ILuDouGaoView : IView
    {
        void SetListener(ILuDouGaoListener listener);
    }
}