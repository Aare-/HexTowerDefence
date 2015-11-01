using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HexPositionComponent : IComponent {
    public int x;
    public int y;
    public int z;
    public float elevation;

    public static HexPositionComponent FromPixelCoordinates() {
        HexPositionComponent position = new HexPositionComponent();

        return position;
    }
}
