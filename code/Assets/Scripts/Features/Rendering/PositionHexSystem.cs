using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PositionHexSystem : IReactiveSystem, IEnsureComponents {
    public TriggerOnEvent trigger { get { return Matcher.HexPosition.OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return Matcher.AllOf(Matcher.View); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            float tileX = 0.0f;
            float tileY = 0.0f;
            float tileElevation = GameController.Instance.ElevationLevel * e.hexPosition.elevation;

            e.view.gameObject.transform.position = new Vector3(tileX, tileElevation, tileY);
        }
    }
}