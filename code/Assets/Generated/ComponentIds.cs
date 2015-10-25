public static class ComponentIds {
    public const int Destroy = 0;
    public const int Enemy = 1;
    public const int HexPosition = 2;
    public const int HexTileDefinition = 3;
    public const int Killable = 4;
    public const int MapDefinition = 5;
    public const int Position = 6;
    public const int Resource = 7;
    public const int TurretDefinition = 8;
    public const int View = 9;

    public const int TotalComponents = 10;

    public static readonly string[] componentNames = {
        "Destroy",
        "Enemy",
        "HexPosition",
        "HexTileDefinition",
        "Killable",
        "MapDefinition",
        "Position",
        "Resource",
        "TurretDefinition",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(Enemy),
        typeof(HexPosition),
        typeof(HexTileDefinition),
        typeof(Killable),
        typeof(MapDefinition),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(TurretDefinition),
        typeof(ViewComponent)
    };
}