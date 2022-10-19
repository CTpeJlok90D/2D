using TMPro;
using UnityEngine;

namespace Weapons
{
    public class WeaponView : MonoBehaviour
    {
        [Header("Image")]
        [SerializeField] private Weapon _weapon;
        [SerializeField] private Sprite _onFloorSprite;
        [SerializeField] private Sprite _inHandsSprite;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void UpdateSpriteOnCurrentState()
        {
            if (_weapon.OnFloor)
            {
                _spriteRenderer.sprite = _onFloorSprite;
                return;
            }
            _spriteRenderer.sprite = _inHandsSprite;
        }
    }
}
