using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.View
{
    public interface ILoadingView : IView
    {
        IEnumerator Show(string tips);

        new IEnumerator Hide();
    }
}
