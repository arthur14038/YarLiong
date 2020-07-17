using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YarLiong.Model
{
    public class GomokuCheePon : CheePon
    {
        public GomokuCheePon(int width, int height) : base(width, height)
        {
            mAllNodes = new Node[width, height];
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    mAllNodes[i, j] = new GomokuNode(i, j, width, height);

            Width = width;
            Height = height;
        }

        public GomokuNode[] GetRightSideNodes(int x, int y, int count)
        {
            List<GomokuNode> rightSideNodes = new List<GomokuNode>();
            int rightSideEnd = x + 1 + count;
            if (rightSideEnd > Width)
                rightSideEnd = Width;
            for (int i = x + 1; i < rightSideEnd; ++i)
            {
                rightSideNodes.Add(mAllNodes[i, y] as GomokuNode);
            }
            return rightSideNodes.ToArray();
        }

        public GomokuNode[] GetLeftSideNodes(int x, int y, int count)
        {
            List<GomokuNode> leftSideNodes = new List<GomokuNode>();
            int leftSideEnd = x -1- count;
            if (leftSideEnd < -1)
                leftSideEnd = -1;
            for (int i = x - 1; i > leftSideEnd; --i)
            {
                leftSideNodes.Add(mAllNodes[i, y] as GomokuNode);
            }
            return leftSideNodes.ToArray();
        }

        public GomokuNode[] GetDownSideNodes(int x, int y, int count)
        {
            List<GomokuNode> downSideNodes = new List<GomokuNode>();
            int downSideEnd = y + 1 + count;
            if (downSideEnd > Height)
                downSideEnd = Height;
            for (int i = y + 1; i < downSideEnd; ++i)
            {
                downSideNodes.Add(mAllNodes[x, i] as GomokuNode);
            }
            return downSideNodes.ToArray();
        }

        public GomokuNode[] GetUpSideNodes(int x, int y, int count)
        {
            List<GomokuNode> upSideNodes = new List<GomokuNode>();

            int upSideEnd = y - 1 - count;
            if (upSideEnd < -1)
                upSideEnd = -1;
            for (int i = y - 1; i > upSideEnd; --i)
            {
                upSideNodes.Add(mAllNodes[x, i] as GomokuNode);
            }
            return upSideNodes.ToArray();
        }

        public GomokuNode[] GetRightDownObliqueNodes(int x, int y, int count)
        {
            List<GomokuNode> rightDownObliqueNodes = new List<GomokuNode>();

            for(int i = 0; i < count; ++i)
            {
                x++;
                y++;
                if (x >= Width)
                    break;
                if (y >= Height)
                    break;
                rightDownObliqueNodes.Add(mAllNodes[x, y] as GomokuNode);
            }

            return rightDownObliqueNodes.ToArray();
        }

        public GomokuNode[] GetRightUpObliqueNodes(int x, int y, int count)
        {
            List<GomokuNode> rightUpObliqueNodes = new List<GomokuNode>();

            for (int i = 0; i < count; ++i)
            {
                x++;
                y--;
                if (x >= Width)
                    break;
                if (y < 0)
                    break;
                rightUpObliqueNodes.Add(mAllNodes[x, y] as GomokuNode);
            }

            return rightUpObliqueNodes.ToArray();
        }

        public GomokuNode[] GetLeftDownObliqueNodes(int x, int y, int count)
        {
            List<GomokuNode> leftDownObliqueNodes = new List<GomokuNode>();

            for (int i = 0; i < count; ++i)
            {
                x--;
                y++;
                if (x < 0)
                    break;
                if (y >= Height)
                    break;
                leftDownObliqueNodes.Add(mAllNodes[x, y] as GomokuNode);
            }

            return leftDownObliqueNodes.ToArray();
        }

        public GomokuNode[] GetLeftUpObliqueNodes(int x, int y, int count)
        {
            List<GomokuNode> leftUpObliqueNodes = new List<GomokuNode>();

            for (int i = 0; i < count; ++i)
            {
                x--;
                y--;
                if (x < 0)
                    break;
                if (y < 0)
                    break;
                leftUpObliqueNodes.Add(mAllNodes[x, y] as GomokuNode);
            }

            return leftUpObliqueNodes.ToArray();
        }
    }
}