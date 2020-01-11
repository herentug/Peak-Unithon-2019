using Game.Core.ItemBase;
using Game.Managers;

namespace Game.Items
{
    public class ColorBalloonItem : Item
    {
        public void PrepareColorBalloonItem(ItemBase itemBase)
        {
            var balloonSprite = ServiceProvider.GetImageLibrary.BalloonSprite;
            Prepare(itemBase, balloonSprite);
        }
    }
}