using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PositionHexSystem : IReactiveSystem, IEnsureComponents {
    public TriggerOnEvent trigger { get { return Matcher.AllOf(Matcher.HexPosition, Matcher.View).OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return Matcher.AllOf(Matcher.View); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            float q = e.hexPosition.x;
            float r = e.hexPosition.z;
                
            float x = (float)(GameController.Instance.TileSize * Math.Sqrt(3.0f) * (q + r/2.0f));
            float y = y = GameController.Instance.TileSize * 3.0f / 2.0f * r;
            
            float tileElevation = GameController.Instance.ElevationLevelUnit * e.hexPosition.elevation;            

            e.view.gameObject.transform.position = new Vector3(x, tileElevation, y);
        }
    }
}