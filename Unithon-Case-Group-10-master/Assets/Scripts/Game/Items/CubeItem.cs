using Game.Core.Enums;
using Game.Core.ItemBase;
using Game.Managers;
using UnityEngine;

namespace Game.Items
{
    public class CubeItem : Item
    {
        private Sprite _defaultSprite;
        private Sprite _hintedSprite;

        private MatchType _matchType;

        private bool _hinted;
        
        public void PrepareCubeItem(ItemBase itemBase, MatchType matchType)
        {
            _matchType = matchType;
            SetSpritesForMatchType();
            Prepare(itemBase, _defaultSprite);
        }
        private void SetSpritesForMatchType()
        {
            var imageLibrary = ServiceProvider.GetImageLibrary;
            
            switch (_matchType)
            {
                case MatchType.Green:
                    _defaultSprite = imageLibrary.GreenCubeSprite;
                    _hintedSprite = imageLibrary.GreenCubeBombHintSprite;
                    break;
                case MatchType.Yellow:
                    _defaultSprite = imageLibrary.YellowCubeSprite;
                    _hintedSprite = imageLibrary.YellowCubeBombHintSprite;
                    break;
                case MatchType.Blue:
                    _defaultSprite = imageLibrary.BlueCubeSprite;
                    _hintedSprite = imageLibrary.BlueCubeBombHintSprite;
                    break;
                case MatchType.Red:
                    _defaultSprite = imageLibrary.RedCubeSprite;
                    _hintedSprite = imageLibrary.RedCubeBombHintSprite;
                    break;
            }
        }

        public override MatchType GetMatchType()
        {
            return _matchType;
        }

        public override bool CanBeMatchedByTouch()
        {
            return true;
        }

        public override bool TryExecute()
        {
            ServiceProvider.GetParticleManager.PlayCubeParticle(this);
            
            return base.TryExecute();
        }

        public override void SetHinted(bool hinted)
        {
            if (_hinted == hinted) return;
            SpriteRenderer.sprite = hinted ? _hintedSprite : _defaultSprite;
            _hinted = hinted;
        }
    }
}
