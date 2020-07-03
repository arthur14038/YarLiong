using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface IMainSceneView : IView
    {
        void SetListener(IMainSceneListener listener);
    }
}