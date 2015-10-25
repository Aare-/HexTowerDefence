public static class ComponentIds {
    public const int Destroy = 0;
    public const int Enemy = 1;
    public const int HexPosition = 2;
    public const int HexTileDefinition = 3;
    public const int MapDefinition = 4;
    public const int Movable = 5;
    public const int Position = 6;
    public const int Resource = 7;
    public const int View = 8;

    public const int TotalComponents = 9;

    public static readonly string[] componentNames = {
        "Destroy",
        "Enemy",
        "HexPosition",
        "HexTileDefinition",
        "MapDefinition",
        "Movable",
        "Position",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(Enemy),
        typeof(HexPosition),
        typeof(HexTileDefinition),
        typeof(MapDefinition),
        typeof(Movable),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}