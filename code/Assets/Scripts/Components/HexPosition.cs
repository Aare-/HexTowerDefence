using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HexPosition : IComponent {
    public int x;
    public int y;
    public int z;
    public float elevation;

    public static HexPosition FromPixelCoordinates() {
        HexPosition position = new HexPosition();

        return position;
    }
}
