using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ResourceComponent : IComponent {
    public enum ViewContainer {
        ui,
        game_scene,
        camera
    }

    public ViewContainer container;
    public string name;
}
