using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TurretDefinition : IComponent{
    public enum TileType {
        red,
        blue,
        black,
        yellow
    }
    public float rateOfFire;
    public float power;

}