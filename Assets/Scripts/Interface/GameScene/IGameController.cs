using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Controller
{
    public interface IGameController : IController
    {
        void StartGame();

        void SetGameEndListener(IGameEndListener gameEndListener);

        void OnDestroy();

        void Update();
    }
}
