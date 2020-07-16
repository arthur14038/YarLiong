using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.View;

namespace YarLiong.Controller
{
    public interface ICheePonController : IController
    {
        void SetView(ICheePonGameView view);
    }
}
