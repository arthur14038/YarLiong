﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Controller
{
    public interface IScrollViewListener
    {
        void OnScrollViewValueChanged(float value);
    }
}