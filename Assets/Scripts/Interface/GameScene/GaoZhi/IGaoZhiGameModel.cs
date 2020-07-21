using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public enum GaoZhiGameType
    {
        Snake,
    }

    public interface IGaoZhiGameModel
    {
        GaoZhiGameType CurrentGaoZhiGameType { get; set; }
    }
}