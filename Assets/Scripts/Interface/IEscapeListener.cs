using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.View;

namespace YarLiong.Controller
{
    public interface IEscapeListener
    {
        void OnClickEscape(ViewPage currentViewPage);
    }
}