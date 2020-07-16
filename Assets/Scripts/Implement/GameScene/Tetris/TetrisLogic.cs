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

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //旋轉
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //下墜
                MoveDown();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //右移
                MoveRigth();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //左移
                MoveLeft();
            }
        }

        #region 生成方塊

        private void CreateNewPattern()
        {
            //有7種型態
            var pattern = (BlockNode.BlockPattern)Random.Range(1, 8);
            mBlockGroup = GetBlockGroup(pattern);
            SetBlockPattern(mBlockGroup, pattern);

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

        
        #endregion



        #region 方塊移動

        private void MoveDown()
        {
            Debug.Log("MoveDown");
            var pattern = mBlockGroup[0].Pattern;

            var newBlocks = new BlockNode[4];

            for (int i = 0; i < mBlockGroup.Length; i++)
            {
                var newBlock = mTetrisGrid.GetNode(mBlockGroup[i].X, mBlockGroup[i].Y + 1);

                if (newBlock == null)
                {
                    Debug.LogWarning("Can't move down");
                    return;
                }

                newBlocks[i] = newBlock;
            }

            var oldBlocks = mBlockGroup;
            SetBlockPattern(oldBlocks, BlockNode.BlockPattern.None);

            SetBlockPattern(newBlocks, pattern);
            mBlockGroup = newBlocks;
        }

        private void MoveRigth()
        {
            Debug.Log("MoveRigth");
            var pattern = mBlockGroup[0].Pattern;

            var newBlocks = new BlockNode[4];

            for (int i = 0; i < mBlockGroup.Length; i++)
            {
                var newBlock = mTetrisGrid.GetNode(mBlockGroup[i].X + 1, mBlockGroup[i].Y);

                if (newBlock == null)
                {
                    Debug.LogWarning("Can't move right");
                    return;
                }

                newBlocks[i] = newBlock;
            }

            var oldBlocks = mBlockGroup;
            SetBlockPattern(oldBlocks, BlockNode.BlockPattern.None);

            SetBlockPattern(newBlocks, pattern);
            mBlockGroup = newBlocks;
        }

        private void MoveLeft()
        {
            Debug.Log("MoveLeft");
            var pattern = mBlockGroup[0].Pattern;

            var newBlocks = new BlockNode[4];

            for (int i = 0; i < mBlockGroup.Length; i++)
            {
                var newBlock = mTetrisGrid.GetNode(mBlockGroup[i].X - 1, mBlockGroup[i].Y);

                if (newBlock == null)
                {
                    Debug.LogWarning("Can't move left");
                    return;
                }

                newBlocks[i] = newBlock;
            }

            var oldBlocks = mBlockGroup;
            SetBlockPattern(oldBlocks, BlockNode.BlockPattern.None);

            SetBlockPattern(newBlocks, pattern);
            mBlockGroup = newBlocks;
        }

        #endregion

        private void SetBlockPattern(BlockNode[] blockNodes, BlockNode.BlockPattern blockPattern)
        {
            for (int i = 0; i < blockNodes.Length; i++)
            {
                blockNodes[i].SetBlockPattern(blockPattern);
            }

            m_GridView.SetBlockView(blockNodes);
        }

    }
}