using Game.Core.BoardBase;
using Game.Core.ItemBase;
using Game.Managers;
using UnityEngine;

namespace Game.Items
{	
	public class BombItem : Item
	{
		private bool _isAlreadyExploded;

		public void PrepareBombItem(ItemBase itemBase)
		{
			var bombSprite = ServiceProvider.GetImageLibrary.BombSprite;
			Prepare(itemBase, bombSprite);
		}
		
		public override bool CanBeExplodedByTouch()
		{
			return true;
		}
		
		public override bool TryExecute()
		{
			if (_isAlreadyExploded) return false;
			_isAlreadyExploded = true;

			var minX = Mathf.Max(0, Cell.X - 1);
			var maxX = Mathf.Min(Board.Cols - 1, Cell.X + 1);

			var minY = Mathf.Max(0, Cell.Y - 1);
			var maxY = Mathf.Min(Board.Rows - 1, Cell.Y + 1);

			for (var x = minX; x <= maxX; x++)
			{
				for (var y = minY; y <= maxY; y++)
				{
					var cell = Cell.Board.Cells[x, y];

					if (cell.HasItem())
					{
						cell.Item.TryExecute();
					}
				}
			}

			return base.TryExecute();
		}		
	}
}
