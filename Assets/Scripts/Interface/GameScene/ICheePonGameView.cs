using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;

namespace YarLiong.View
{
    public interface ICheePonGameView: IView
    {
        void SetCheePon(CheePon cheePonData, ICheePonNodeListener cheePonNodeListener);
    }
}