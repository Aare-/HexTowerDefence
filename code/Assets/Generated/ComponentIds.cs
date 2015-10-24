public static class ComponentIds {
    public const int Destroy = 0;
    public const int HexTile = 1;
    public const int MapSize = 2;
    public const int Position = 3;
    public const int Resource = 4;
    public const int View = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "Destroy",
        "HexTile",
        "MapSize",
        "Position",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(HexTile),
        typeof(MapSize),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}