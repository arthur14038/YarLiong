using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YarLiong.Controller;
using YarLiong.Model;

namespace YarLiong.View
{
    public class LuDouGaoView : AbstractView, ILuDouGaoView
    {
        [SerializeField]
        private Button m_TetrisBtn = null;
        [SerializeField]
        private Button m_BackBtn = null;

        ILuDouGaoListener mLuDouGaoListener = null;

        public override IEnumerator Init()
        {
            m_BackBtn.onClick.AddListener(() => { mLuDouGaoListener.OnClickEscape(ViewPage.LuDouGao); });
            m_TetrisBtn.onClick.AddListener(() => { mLuDouGaoListener.OnClickGame(GameType.Tetris); });

            yield return null;
        }

        public void SetListener(ILuDouGaoListener listener)
        {
            mLuDouGaoListener = listener;
        }
    }
}