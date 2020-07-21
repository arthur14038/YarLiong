using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Controller
{
    public interface IGameSettingListener
    {
        void OnClickStart();

        void OnClickFinish();

        void OnClickAgain();
    }
}