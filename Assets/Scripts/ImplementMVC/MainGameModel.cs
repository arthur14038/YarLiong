using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Model;

public class MainGameModel : IMainGameModel
{
    string[] loadingTips = { "為了減少摩擦，增進和諧，我們必須努力培養雅量。",
        "人與人偶有摩擦，往往都是由於缺乏那分雅量的緣故。", 
        "人與人之間，應該有彼此容忍和尊重對方的看法與觀點的雅量。", 
    };

    public string GetLoadingTips()
    {
        return loadingTips[Random.Range(0, loadingTips.Length)];
    }
}
