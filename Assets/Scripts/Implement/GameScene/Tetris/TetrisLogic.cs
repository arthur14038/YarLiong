using System;
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
        public enum MoveDirection
        {
            Down = 0,
            Right = 1,
            Left = 2,
        }

        const int WIDTH = 10;
        const int HEIGHT = 20;

        [SerializeField]
        private GridView m_GridView = null;

        TetrisGrid mTetrisGrid;

        //BlockNode[] mBlockGroup = null;

        BlockPattern mBlockPattern = null;

        float mFallDownTime = 0.5f;
        float mTimer = 0f;

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
                //順時針旋轉
                TurnRight();
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

            if (Input.GetKeyDown(KeyCode.Z))
            {
                //逆時針轉
                TurnLeft();
            }

            if (mTimer < mFallDownTime)
            {
                mTimer += Time.deltaTime;
            }
            else
            {
                if (mBlockPattern == null)
                    CreateNewPattern();
                //else
                //    MoveDown();
                mTimer = 0f;
            }
        }

        #region 生成方塊

        private void CreateNewPattern()
        {
            mBlockPattern = new BlockPattern();
            var blockGroup = GetBlockGroup(mBlockPattern.PatternType);
            mBlockPattern.SetBlockNodes(blockGroup);
            mBlockPattern.InitPivot(mBlockPattern.PatternType);

            SetView(mBlockPattern);
        }

        private BlockNode[] GetBlockGroup(BlockPattern.Pattern blockPattern)
        {
            var blockGroup = new BlockNode[4];

            switch (blockPattern)
            {
                case BlockPattern.Pattern.S:
                    blockGroup[0] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[2] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(3, 1);
                    break;
                case BlockPattern.Pattern.Z:
                    blockGroup[0] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(6, 1);
                    break;
                case BlockPattern.Pattern.L:
                    blockGroup[0] = mTetrisGrid.GetNode(6, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(6, 1);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(4, 1);
                    break;
                case BlockPattern.Pattern.J:
                    blockGroup[0] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(6, 1);
                    break;
                case BlockPattern.Pattern.T:
                    blockGroup[0] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[2] = mTetrisGrid.GetNode(5, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(6, 1);
                    break;
                case BlockPattern.Pattern.O:
                    blockGroup[0] = mTetrisGrid.GetNode(4, 0);
                    blockGroup[1] = mTetrisGrid.GetNode(5, 0);
                    blockGroup[2] = mTetrisGrid.GetNode(4, 1);
                    blockGroup[3] = mTetrisGrid.GetNode(5, 1);
                    break;
                case BlockPattern.Pattern.I:
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
            if (mBlockPattern == null)
                return;

            Debug.Log("MoveDown");
            var pattern = mBlockPattern.PatternType;
            var blockGroup = mBlockPattern.BlockNodes;

            var newBlocks = new BlockNode[4];

            //觸底或是下方有別的方塊
            if (mTetrisGrid.IsGround(blockGroup) || mTetrisGrid.IsBlock(blockGroup, (int)MoveDirection.Down))
            {
                SetBlocksType(blockGroup, BlockNode.BlockType.Stuck);
                mBlockPattern = null;

                Debug.LogWarning("Can't move down");
            }
            else
            {
                var oldBlocks = mBlockPattern.BlockNodes;
                ClearBlockStatus(oldBlocks);

                for (int i = 0; i < blockGroup.Length; i++)
                {
                    newBlocks[i] = mTetrisGrid.GetNode(blockGroup[i].X, blockGroup[i].Y + 1);
                }

                mBlockPattern.SetBlockNodes(newBlocks);
                SetView(mBlockPattern);

                mBlockPattern.Pivot += new Vector3(0, 1, 0);
            }
        }

        private void MoveRigth()
        {
            if (mBlockPattern == null)
                return;

            if (mTetrisGrid.IsBlock(mBlockPattern.BlockNodes, (int)MoveDirection.Right))
            {
                Debug.LogWarning("Can't move right, is block");
                return;
            }

            Debug.Log("MoveRigth");
            var pattern = mBlockPattern.PatternType;
            var blockGroup = mBlockPattern.BlockNodes;

            var newBlocks = new BlockNode[4];

            for (int i = 0; i < blockGroup.Length; i++)
            {
                var newBlock = mTetrisGrid.GetNode(blockGroup[i].X + 1, blockGroup[i].Y);

                if (newBlock == null)
                {
                    Debug.LogWarning("Can't move right");
                    return;
                }

                newBlocks[i] = newBlock;
            }

            var oldBlocks = blockGroup;
            ClearBlockStatus(oldBlocks);

            mBlockPattern.SetBlockNodes(newBlocks);
            SetView(mBlockPattern);

            mBlockPattern.Pivot += new Vector3(1, 0, 0);
        }

        private void MoveLeft()
        {
            if (mBlockPattern == null)
                return;

            if (mTetrisGrid.IsBlock(mBlockPattern.BlockNodes, (int)MoveDirection.Left))
            {
                Debug.LogWarning("Can't move left, is block");
                return;
            }

            Debug.Log("MoveLeft");
            var pattern = mBlockPattern.PatternType;
            var blockGroup = mBlockPattern.BlockNodes;

            var newBlocks = new BlockNode[4];

            for (int i = 0; i < blockGroup.Length; i++)
            {
                var newBlock = mTetrisGrid.GetNode(blockGroup[i].X - 1, blockGroup[i].Y);

                if (newBlock == null)
                {
                    Debug.LogWarning("Can't move left");
                    return;
                }

                newBlocks[i] = newBlock;
            }

            var oldBlocks = blockGroup;
            ClearBlockStatus(oldBlocks);

            mBlockPattern.SetBlockNodes(newBlocks);
            SetView(mBlockPattern);

            mBlockPattern.Pivot += new Vector3(-1, 0, 0);
        }

        #endregion

        #region 方塊旋轉

        private void TurnRight()
        {
            if (mBlockPattern == null)
                return;

            var nodes = mBlockPattern.BlockNodes;
            var newBlocks = new BlockNode[4];

            switch (mBlockPattern.PatternType)
            {
                case BlockPattern.Pattern.O:
                    return;
                case BlockPattern.Pattern.S:
                case BlockPattern.Pattern.Z:
                case BlockPattern.Pattern.L:
                case BlockPattern.Pattern.J:
                case BlockPattern.Pattern.T:
                case BlockPattern.Pattern.I:
                    Vector3 pivot = mBlockPattern.Pivot;
                    var p0 = RotatePointAroundPivot(nodes[0].Point, pivot, Quaternion.AngleAxis(90, Vector3.forward));
                    var p1 = RotatePointAroundPivot(nodes[1].Point, pivot, Quaternion.AngleAxis(90, Vector3.forward));
                    var p2 = RotatePointAroundPivot(nodes[2].Point, pivot, Quaternion.AngleAxis(90, Vector3.forward));
                    var p3 = RotatePointAroundPivot(nodes[3].Point, pivot, Quaternion.AngleAxis(90, Vector3.forward));

                    newBlocks[0] = mTetrisGrid.GetNode(Convert.ToInt32(p0.x), Convert.ToInt32(p0.y));
                    newBlocks[1] = mTetrisGrid.GetNode(Convert.ToInt32(p1.x), Convert.ToInt32(p1.y));
                    newBlocks[2] = mTetrisGrid.GetNode(Convert.ToInt32(p2.x), Convert.ToInt32(p2.y));
                    newBlocks[3] = mTetrisGrid.GetNode(Convert.ToInt32(p3.x), Convert.ToInt32(p3.y));

                    #region dirty
                    //if (mBlockPattern.CurrentModelIndex == 0)
                    //{
                    //    if (mTetrisGrid.GetNode(nodes[0].X, nodes[0].Y - 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X, nodes[1].Y - 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X, nodes[2].Y - 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X, nodes[2].Y + 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X, nodes[2].Y + 2)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[3].X, nodes[3].Y + 1)?.Type != BlockNode.BlockType.Stuck)
                    //    {
                    //        newBlocks[0] = mTetrisGrid.GetNode(nodes[0].X + 2, nodes[0].Y - 1);
                    //        newBlocks[1] = mTetrisGrid.GetNode(nodes[1].X + 1, nodes[1].Y);
                    //        newBlocks[2] = mTetrisGrid.GetNode(nodes[2].X, nodes[2].Y + 1);
                    //        newBlocks[3] = mTetrisGrid.GetNode(nodes[3].X - 1, nodes[3].Y + 2);
                    //    }
                    //}
                    //else if (mBlockPattern.CurrentModelIndex == 1)
                    //{
                    //    if (mTetrisGrid.GetNode(nodes[0].X + 1, nodes[0].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X + 1, nodes[1].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X + 1, nodes[2].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X - 1, nodes[2].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X - 2, nodes[2].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[3].X - 1, nodes[3].Y)?.Type != BlockNode.BlockType.Stuck)
                    //    {
                    //        newBlocks[0] = mTetrisGrid.GetNode(nodes[0].X - 2, nodes[0].Y + 2);
                    //        newBlocks[1] = mTetrisGrid.GetNode(nodes[1].X - 1, nodes[1].Y + 1);
                    //        newBlocks[2] = mTetrisGrid.GetNode(nodes[2].X, nodes[2].Y);
                    //        newBlocks[3] = mTetrisGrid.GetNode(nodes[3].X + 1, nodes[3].Y - 1);
                    //    }
                    //}
                    //else if (mBlockPattern.CurrentModelIndex == 2)
                    //{
                    //    if (mTetrisGrid.GetNode(nodes[0].X, nodes[0].Y + 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X, nodes[1].Y - 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X, nodes[1].Y - 2)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X, nodes[1].Y + 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X, nodes[2].Y + 1)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[3].X, nodes[3].Y + 1)?.Type != BlockNode.BlockType.Stuck)
                    //    {
                    //        newBlocks[0] = mTetrisGrid.GetNode(nodes[0].X + 1, nodes[0].Y - 2);
                    //        newBlocks[1] = mTetrisGrid.GetNode(nodes[1].X, nodes[1].Y - 1);
                    //        newBlocks[2] = mTetrisGrid.GetNode(nodes[2].X - 1, nodes[2].Y);
                    //        newBlocks[3] = mTetrisGrid.GetNode(nodes[3].X - 2, nodes[3].Y + 1);
                    //    }
                    //}
                    //else if (mBlockPattern.CurrentModelIndex == 3)
                    //{
                    //    if (mTetrisGrid.GetNode(nodes[0].X + 1, nodes[0].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X + 1, nodes[1].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X + 2, nodes[1].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[1].X - 1, nodes[1].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[2].X - 1, nodes[2].Y)?.Type != BlockNode.BlockType.Stuck &&
                    //       mTetrisGrid.GetNode(nodes[3].X - 1, nodes[3].Y)?.Type != BlockNode.BlockType.Stuck)
                    //    {
                    //        newBlocks[0] = mTetrisGrid.GetNode(nodes[0].X - 1, nodes[0].Y + 1);
                    //        newBlocks[1] = mTetrisGrid.GetNode(nodes[1].X, nodes[1].Y);
                    //        newBlocks[2] = mTetrisGrid.GetNode(nodes[2].X + 1, nodes[2].Y - 1);
                    //        newBlocks[3] = mTetrisGrid.GetNode(nodes[3].X + 2, nodes[3].Y - 2);
                    //    }
                    //}
                    #endregion

                    break;
            }

            //檢查有沒有拿到空的或是已落定的方塊
            for (int i = 0; i < newBlocks.Length; i++)
            {
                if (newBlocks[i] == null || newBlocks[i].Type == BlockNode.BlockType.Stuck)
                    return;
            }

            mBlockPattern.CurrentModelIndex = (mBlockPattern.CurrentModelIndex + 1) % 4;

            var oldBlocks = mBlockPattern.BlockNodes;
            ClearBlockStatus(oldBlocks);

            mBlockPattern.SetBlockNodes(newBlocks);
            SetView(mBlockPattern);
        }

        private void TurnLeft()
        {
            if (mBlockPattern == null)
                return;

            var nodes = mBlockPattern.BlockNodes;
            var newBlocks = new BlockNode[4];

            switch (mBlockPattern.PatternType)
            {
                case BlockPattern.Pattern.O:
                    return;
                case BlockPattern.Pattern.S:
                case BlockPattern.Pattern.Z:
                case BlockPattern.Pattern.L:
                case BlockPattern.Pattern.J:
                case BlockPattern.Pattern.T:
                case BlockPattern.Pattern.I:
                    Vector3 pivot = mBlockPattern.Pivot;
                    var p0 = RotatePointAroundPivot(nodes[0].Point, pivot, Quaternion.AngleAxis(-90, Vector3.forward));
                    var p1 = RotatePointAroundPivot(nodes[1].Point, pivot, Quaternion.AngleAxis(-90, Vector3.forward));
                    var p2 = RotatePointAroundPivot(nodes[2].Point, pivot, Quaternion.AngleAxis(-90, Vector3.forward));
                    var p3 = RotatePointAroundPivot(nodes[3].Point, pivot, Quaternion.AngleAxis(-90, Vector3.forward));

                    newBlocks[0] = mTetrisGrid.GetNode(Convert.ToInt32(p0.x), Convert.ToInt32(p0.y));
                    newBlocks[1] = mTetrisGrid.GetNode(Convert.ToInt32(p1.x), Convert.ToInt32(p1.y));
                    newBlocks[2] = mTetrisGrid.GetNode(Convert.ToInt32(p2.x), Convert.ToInt32(p2.y));
                    newBlocks[3] = mTetrisGrid.GetNode(Convert.ToInt32(p3.x), Convert.ToInt32(p3.y));

                    break;
            }

            //檢查有沒有拿到空的或是已落定的方塊
            for (int i = 0; i < newBlocks.Length; i++)
            {
                if (newBlocks[i] == null || newBlocks[i].Type == BlockNode.BlockType.Stuck)
                    return;
            }

            mBlockPattern.CurrentModelIndex = (mBlockPattern.CurrentModelIndex + 1) % 4;

            var oldBlocks = mBlockPattern.BlockNodes;
            ClearBlockStatus(oldBlocks);

            mBlockPattern.SetBlockNodes(newBlocks);
            SetView(mBlockPattern);
        }

        #endregion

        private void SetView(BlockPattern blockPattern)
        {
            m_GridView.SetBlockView(blockPattern.BlockNodes);
        }

        //[System.Obsolete("use SetView(BlockPattern blockPattern)")]
        //private void SetBlocksPattern(BlockNode[] blockNodes, BlockPattern.Pattern blockPattern)
        //{
        //    for (int i = 0; i < blockNodes.Length; i++)
        //    {
        //        blockNodes[i].SetBlockPattern(blockPattern);
        //    }

        //    m_GridView.SetBlockView(blockNodes);
        //}

        private void SetBlocksType(BlockNode[] blockNodes, BlockNode.BlockType blockType)
        {
            for (int i = 0; i < blockNodes.Length; i++)
            {
                blockNodes[i].SetBlockType(blockType);
            }
        }

        private void ClearBlockStatus(BlockNode[] blockNodes)
        {
            for (int i = 0; i < blockNodes.Length; i++)
            {
                blockNodes[i].SetBlockPattern(BlockPattern.Pattern.None);
                blockNodes[i].SetBlockType(BlockNode.BlockType.None);
            }

            m_GridView.SetBlockView(blockNodes);
        }

        private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
        {
            return rotation * (point - pivot) + pivot;
        }
    }
}