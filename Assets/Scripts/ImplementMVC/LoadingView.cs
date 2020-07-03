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

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public IEnumerator Show(string tips)
        {
            var doText = m_LoadingText.DOText(tips, 3f).Play();
            yield return doText.WaitForCompletion();

            var doFade = m_LoadingText.DOFade(0f, 1f).Play();
            yield return doFade.WaitForCompletion();
        }

        public new IEnumerator Hide()
        {
            yield return null;

            base.Hide();
        }

        public override IEnumerator Init()
        {
            yield return null;
        }
    }
}