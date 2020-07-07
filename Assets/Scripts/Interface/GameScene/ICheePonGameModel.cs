using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public enum CheePonGameType
    {
        Gomoku,
    }

    public interface ICheePonGameModel
    {
        CheePonGameType CurrentCheePonGameType { get; set; }
    }
}