﻿using Game.Core.BoardBase;
using Game.Core.Enums;
using Game.Core.LevelBase;

namespace Game.Levels
{
    public class LevelData_0 : LevelData
    {
        public override ItemType GetNextFillItemType()
        {
            return GetRandomCubeItemType();
        }

        public override void Initialize()
        {
            GridData = new ItemType[Board.Rows, Board.Cols];

            for (var y = 0; y < Board.Rows; y++)
            {
                for (var x = 0; x < Board.Cols; x++)
                {
                    GridData[x, y] = GetRandomCubeItemType();
                }
            }
        }
    }
}