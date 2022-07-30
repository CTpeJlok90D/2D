public enum Direction
{
	Right,
	Left,
}
public static class DirectionConvert
{
    public static int ToInt(Direction direction)
    {
        return direction == Direction.Right ? 1 : -1;
    }
}