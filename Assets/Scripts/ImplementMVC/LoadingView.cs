using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace YarLiong.View
{
    public class LoadingView : MonoBehaviour, ILoadingView
    {
        [SerializeField]
        private Canvas m_Canvas = null;
        [SerializeField]
        private CanvasGroup m_CanvasGroup = null;
        [SerializeField]
        private Text m_LoadingText = null;

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator Hide()
        {
            yield return null;
            Hide();
        }

        public IEnumerator Init()
        {
            yield return null;
        }

        public IEnumerator Show(string tips)
        {
            var doText = m_LoadingText.DOText(tips, 3f).Play();

            yield return doText.WaitForCompletion();

            var doFade = m_LoadingText.DOFade(0f, 1f).Play();

            yield return doFade.WaitForCompletion();
        }

        public void Show()
        {
            m_Canvas.enabled = true;
            m_CanvasGroup.alpha = 1;
        }

        void IView.Hide()
        {
            m_Canvas.enabled = false;
            m_CanvasGroup.alpha = 0;
        }

    }
}