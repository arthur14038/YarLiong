using System.Collections;

namespace YarLiong.View
{
    public interface IView
    {
        IEnumerator Init();

        void Show();

        void Hide();

        void Destroy();
    }
}