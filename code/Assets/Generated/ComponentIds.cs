public static class ComponentIds {
    public const int Destroy = 0;
    public const int Position = 1;
    public const int Resource = 2;
    public const int View = 3;

    public const int TotalComponents = 4;

    public static readonly string[] componentNames = {
        "Destroy",
        "Position",
        "Resource",
        "View"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(DestroyComponent),
        typeof(PositionComponent),
        typeof(ResourceComponent),
        typeof(ViewComponent)
    };
}