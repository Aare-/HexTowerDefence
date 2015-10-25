using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PositionComponent : IComponent {
    public float x;
    public float y;
    public float z;

    public static PositionComponent FromHexCoordinates(int hx, int hy, int hz) {
        PositionComponent component = new PositionComponent();

        return component;
    }    
}