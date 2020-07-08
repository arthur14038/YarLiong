using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Controller;
using YarLiong.Model;
using YarLiong.View;

namespace YarLiong
{
    public class TetrisLogic : MonoBehaviour, IController
    {
        const int WIDTH = 10;
        const int HEIGHT = 20;

        [SerializeField]
        private GridView m_GridView = null;

        private void Start()
        {
            StartCoroutine(Init());
        }

        public IEnumerator Init()
        {
            TetrisGrid grid = new TetrisGrid(WIDTH, HEIGHT);
            m_GridView.SetSize(grid);

            yield return null;
        }
    }
}