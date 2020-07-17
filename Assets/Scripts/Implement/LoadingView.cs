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
#if UNITY_EDITOR
        float mTextTime = 0f;
        float mHideTime = 0f;
#else
        float mTextTime = 3f;
        float mHideTime = 1f;
#endif

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public IEnumerator Show(string tips)
        {
            base.Show();

            m_LoadingText.color = mTextColor;

            var doText = m_LoadingText.DOText(tips, mTextTime).Play();
            yield return doText.WaitForCompletion();
        }

        public new IEnumerator Hide()
        {
            var doFade = m_LoadingText.DOFade(0f, mHideTime).Play();
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