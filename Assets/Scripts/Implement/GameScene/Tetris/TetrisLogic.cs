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

        TetrisGrid mTetrisGrid;

        BlockNode[] mBlockGroup = new BlockNode[4];

        private void Start()
        {
            StartCoroutine(Init());
        }

        public IEnumerator Init()
        {
            TetrisGrid grid = new TetrisGrid(WIDTH, HEIGHT);
            m_GridView.SetSize(grid);

            mTetrisGrid = grid;

            yield return null;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CreateNewPattern();
            }
        }

        private void CreateNewPattern()
        {
            //有7種型態
            var pattern = (BlockNode.BlockPattern)Random.Range(1, 8);
            mBlockGroup = GetBlockGroup(pattern);
            mBlockGroup = GetBlockGroup(pattern);
            SetBlockPattern(pattern);

            Debug.Log("pattern = " + pattern);
        }

        private BlockNode[] GetBlockGroup(BlockNode.BlockPattern blockPattern)
        {
            var blockGroup = new BlockNode[4];

            switch (blockPattern)
            {
                case BlockNode.BlockPattern.S:
                    blockGroup[0] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[2] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(3, 1);
                    break;
                case BlockNode.BlockPattern.Z:
                    blockGroup[0] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(6, 1);
                    break;
                case BlockNode.BlockPattern.L:
                    blockGroup[0] = mTetrisGrid.GetNode(6, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(6, 1);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(4, 1);
                    break;
                case BlockNode.BlockPattern.J:
                    blockGroup[0] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(6, 1);
                    break;
                case BlockNode.BlockPattern.T:
                    blockGroup[0] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(6, 1);
                    break;
                case BlockNode.BlockPattern.O:
                    blockGroup[0] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[2] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(5, 1);
                    break;
                case BlockNode.BlockPattern.I:
                    blockGroup[0] = mTetrisGrid.GetNode(3, 1);
                    blockGroup[1] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(6, 1);
                    break;
            }

            return blockGroup;
        }

        private void SetBlockPattern(BlockNode.BlockPattern blockPattern)
        {
            for (int i = 0; i < mBlockGroup.Length; i++)
            {
                mBlockGroup[i].SetBlockPattern(blockPattern);
            }

            m_GridView.SetBlockView(mBlockGroup);
        }

    }
}