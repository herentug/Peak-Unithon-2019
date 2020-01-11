using System.Collections.Generic;
using Game.Core.BoardBase;
using Game.Core.Enums;
using UnityEngine;

namespace Game.Mechanics
{	
	public class MatchManager : MonoBehaviour 
	{
		public Board Board;

		private readonly MatchFinder _matchFinder = new MatchFinder();

		private void Update()
		{		
			_matchFinder.ClearVisitedCells();

			for (var y = 0; y < Board.Rows; y++)
			{
				for (var x = 0; x < Board.Cols; x++)
				{
					var cell = Board.Cells[x, y];

					if (!cell.HasItem() || cell.Item.GetMatchType() == MatchType.None) continue;

					var resultCells = new List<Cell>();
					_matchFinder.FindMatches(cell, cell.Item.GetMatchType(), resultCells);

					foreach (var resultCell in resultCells)
					{
						var item = resultCell.Item;
						if (item != null)
						{
							var setHint = resultCells.Count >= Board.MakeBombCount;
							item.SetHinted(setHint);
						}
					}
				}
			}
		}
	}
}
