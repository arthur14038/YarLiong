using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YarLiong.Model;

namespace YarLiong.View
{
    public interface ISnakeGameView : IGameView
    {
        void SetGround(ISnakeGround snakeGround);

        void SetSnake(INode[] snakeBodies);

        void SetApple(INode applePosition);

        void EmptyNode(INode emptyPosition);
    }
}