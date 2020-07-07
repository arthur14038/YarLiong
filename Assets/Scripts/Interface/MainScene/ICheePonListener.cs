using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Model;

namespace YarLiong.Controller
{
    public interface ICheePonListener: IEscapeListener
    {
        void OnClickGame(CheePonGameType gameType);
    }
}