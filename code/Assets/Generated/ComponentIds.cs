public static class ComponentIds {
    public const int Destroy = 0;
    public const int HexPosition = 1;
    public const int HexTileDefinition = 2;
    public const int MapDefinition = 3;
    public const int Position = 4;
    public const int Resource = 5;
    public const int View = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "Destroy",
        "HexPosition",
        "HexTileDefinition",
        "MapDefinition",
        "Position",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(HexPosition),
        typeof(HexTileDefinition),
        typeof(MapDefinition),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}