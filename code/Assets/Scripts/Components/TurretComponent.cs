using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TurretComponent : IComponent {
    public enum TileType {
        red,
        blue,
        black,
        yellow
    }

    public float rateOfFire;
    public float power;
}