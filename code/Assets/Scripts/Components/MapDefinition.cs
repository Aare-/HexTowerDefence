using Entitas;
using Entitas.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[SingleEntity]
public class MapDefinition : IComponent {
    public int radius;
}