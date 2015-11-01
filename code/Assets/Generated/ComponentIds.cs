public static class ComponentIds {
    public const int Alive = 0;
    public const int Destroy = 1;
    public const int HexPosition = 2;
    public const int HexTileDefinition = 3;
    public const int MapDefinition = 4;
    public const int Movable = 5;
    public const int NestedView = 6;
    public const int Position = 7;
    public const int Resource = 8;
    public const int Turret = 9;
    public const int View = 10;

    public const int TotalComponents = 11;

    public static readonly string[] componentNames = {
        "Alive",
        "Destroy",
        "HexPosition",
        "HexTileDefinition",
        "MapDefinition",
        "Movable",
        "NestedView",
        "Position",
        "Resource",
        "Turret",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(AliveComponent),
        typeof(DestroyComponent),
        typeof(HexPositionComponent),
        typeof(HexTileDefinitionComponent),
        typeof(MapDefinitionComponent),
        typeof(MovableComponent),
        typeof(NestedViewComponent),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(TurretComponent),
        typeof(ViewComponent)
    };
}