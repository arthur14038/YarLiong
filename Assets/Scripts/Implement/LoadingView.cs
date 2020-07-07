using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace YarLiong.View
{
    public class LoadingView : AbstractView, ILoadingView
    {
        [SerializeField]
        private Text m_LoadingText = null;

        private Color mTextColor = new Color(0f, 0f, 0f, 1f);

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public IEnumerator Show(string tips)
        {
            base.Show();

            m_LoadingText.color = mTextColor;

            var doText = m_LoadingText.DOText(tips, 3f).Play();
            yield return doText.WaitForCompletion();
        }

        public new IEnumerator Hide()
        {
            var doFade = m_LoadingText.DOFade(0f, 1f).Play();
            yield return doFade.WaitForCompletion();

            base.Hide();

            m_LoadingText.text = string.Empty;
        }

        public override IEnumerator Init()
        {
            yield return null;
        }
    }
}