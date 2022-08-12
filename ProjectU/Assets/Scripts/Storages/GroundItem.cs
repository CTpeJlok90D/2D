using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]
public class GroundItem : MonoBehaviour
{
    [SerializeField] private Item _item;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;

    public Item Item => _item;

    public GroundItem Init(Item item)
    {
        _item = item;
        _spriteRenderer.sprite = _item.Sprite;
        transform.localScale = _item.LocalScale;
        _collider.size = _item.ColliderScale;

        return this;
    }

    public void PickUpBy()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        Init(_item);
    }
    private void FixedUpdate()
    {

    }
}
