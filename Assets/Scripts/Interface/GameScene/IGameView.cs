using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface IGameView : IView
    {
        void SetListener(IGameBackListener listener);
    }
}