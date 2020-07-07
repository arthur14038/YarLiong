using System.Collections;

namespace YarLiong.View
{
    public enum ViewPage
    {
        MainScene,
        CheePon,
        GaoZhi,
        LuDouGao,
    }

    public interface IView
    {
        IEnumerator Init();

        void Show();

        void Hide();

        void Destroy();
    }
}