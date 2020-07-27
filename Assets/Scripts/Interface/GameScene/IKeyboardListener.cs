using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Controller
{
    public interface IKeyboardListener
    {
        void OnHorizontalClick(bool right);

        void OnVerticalClick(bool up);
    }
}