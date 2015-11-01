using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddViewSystem : IReactiveSystem{
    public TriggerOnEvent trigger { 
        get { return Matcher.Resource.OnEntityAdded(); } 
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities)
            ExecEntity(e);        
    }

    void ExecEntity(Entity e) {
        GameObject gameObject = null;
        var res = Resources.Load<GameObject>(e.resource.name);

        try {
            gameObject = UnityEngine.Object.Instantiate(res);
        } catch (Exception) {
            if(e.hasView) e.RemoveView();
            Debug.Log("Cannot instantiate " + res + " (" + e.resource.name + ")");
            return;
        }

        if (e.hasView) {
            MonoBehaviour.DestroyImmediate(e.view.gameObject);
            e.ReplaceView(gameObject);
        } else
            e.AddView(gameObject);

        gameObject.transform.parent = SceneRoot.Instance.gameObject.transform;        
    }
}

