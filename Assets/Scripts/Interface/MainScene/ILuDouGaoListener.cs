﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Model;

namespace YarLiong.Controller
{
    public interface ILuDouGaoListener: IEscapeListener
    {
        void OnClickGame(GameType gameType);
    }
}