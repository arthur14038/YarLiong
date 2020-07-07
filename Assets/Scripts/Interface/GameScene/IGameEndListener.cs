using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Controller
{
    public interface IGameEndListener
    {
        void OnClickQuit();

        void OnClickGameOver();
    }
}