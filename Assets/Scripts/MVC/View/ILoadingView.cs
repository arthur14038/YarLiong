﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.View
{
    public interface ILoadingView : IView
    {
        void Show(string tips);
    }
}
