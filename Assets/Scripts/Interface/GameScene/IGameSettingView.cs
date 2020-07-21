using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;

namespace YarLiong.View
{
    public interface IGameSettingView: IView
    {
        void SetListener(IGameSettingListener listener);

        void ShowGameStartView();

        void ShowGameEndView(string endingMsg);
    }
}