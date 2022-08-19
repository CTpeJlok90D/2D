using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
	[SerializeField] private Transform[] _lookingItemsView;
	[SerializeField] private Transform[] _rotatingItemsX;
	[SerializeField] private Transform[] _rotatingItemsY;

	public void LookAt(Transform target)
    {
		foreach (Transform transform in _lookingItemsView)
        {
            transform.LookAt(target);
        }
    }

    public void Rotate()
    {
        RotateY();
        RotateX();
    }

    public void RotateX()
    {
        foreach (Transform transform in _rotatingItemsX)
        {
            transform.Rotate(180, 0, 0);
        }
    }

    public void RotateY()
    {
        foreach (Transform transform in _rotatingItemsY)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}