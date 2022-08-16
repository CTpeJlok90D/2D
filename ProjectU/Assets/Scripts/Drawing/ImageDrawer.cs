using UnityEngine;
using UnityEngine.UI;

public class ImageDrawer
{
    private Vector2Int _size;
    private Image _image;
    private Texture2D _texture;
    private RectTransform _rectTransform;


    public ImageDrawer(Image image, RectTransform rectTransform)
    {
        _image = image;
        _rectTransform = rectTransform;
        _size = new Vector2Int((int)_rectTransform.sizeDelta.x, (int)_rectTransform.sizeDelta.y);
        _image.sprite = Sprite.Create(new Texture2D(_size.x, _size.y), new Rect(0, 0, _size.x, _size.y), _rectTransform.pivot);
        _texture = _image.sprite.texture;
        _texture.filterMode = FilterMode.Point;
    }

    public void DrawSquare(Vector2Int point1, Vector2Int point2, Color color)
    {
        for (int x = point1.x; x <= point2.x; x++)
        {
            for (int y = point1.y; y <= point2.y; y++)
            {
                _texture.SetPixel(x, y, color);
            }
        }
        _texture.Apply();
    }
    public void DrawGrid(Vector2Int begin, Vector2Int end, int cellSize, int borderTicknerss, Color color)
    {
        for (int x = begin.x; x <= end.x; x+= cellSize)
        {
            DrawSquare(new Vector2Int(x, begin.y), new Vector2Int(x + borderTicknerss, end.y), color);
        }
        for (int y = begin.y; y <= end.y; y += cellSize)
        {
            DrawSquare(new Vector2Int(begin.x, y), new Vector2Int(end.x, y + borderTicknerss), color);
        }
    }
    public void DrawCell(Vector2Int begin, Vector2Int end, int borderTicknerss, Color color, Color frameColor)
    {
        borderTicknerss++;
        DrawSquare(begin, end, frameColor);
        DrawSquare(new Vector2Int(begin.x + borderTicknerss, begin.y + borderTicknerss), new Vector2Int(end.x - borderTicknerss, end.y - borderTicknerss), color);
    }
    public void DrawSquare(int x1, int y1, int x2, int y2, Color color)
    {
        DrawSquare(new Vector2Int(x1, y1), new Vector2Int(x2, y2), color);
    }
    public void FillByColor(Color color)
    {
        DrawSquare(Vector2Int.zero, _size, color);
    }
}
