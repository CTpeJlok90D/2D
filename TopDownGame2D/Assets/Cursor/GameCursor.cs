using UnityEngine;

public class GameCursor : MonoBehaviour
{
    [SerializeField] private Texture2D _reloadCursor;
    [SerializeField] private Texture2D _standartCursor;

    private static GameCursor _singleTone;

    public void Awake()
    {
        if (_singleTone != null)
        {
            Destroy(this);
            Debug.LogWarning("Multicursor fonud");
            return;
        }
        _singleTone = this;
        SetDefualt();
    }

    public void SetReload()
    {
        Cursor.SetCursor(_reloadCursor, Vector2.zero, CursorMode.Auto);
    }

    public void SetDefualt()
    {
        Cursor.SetCursor(_standartCursor, Vector2.zero, CursorMode.Auto);
    }
}
