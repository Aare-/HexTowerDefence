using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddNestedViewSystem : IReactiveSystem {
    public TriggerOnEvent trigger { 
        get {
            return Matcher.AllOf(Matcher.View, Matcher.Resource, Matcher.NestedView).OnEntityAdded();             
        } 
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            GameObject parent = SceneRoot.Instance.gameObject;
            
            Transform newParent = SceneRoot.Instance.gameObject.transform.Find(e.nestedView.path);
            if (newParent != null) {
                parent = newParent.gameObject;
            }            
            
            e.view.gameObject.transform.parent = parent.transform;
        }
    }
}       