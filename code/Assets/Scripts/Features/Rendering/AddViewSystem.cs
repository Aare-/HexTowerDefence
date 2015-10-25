using Entitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.Resource.OnEntityAdded(); } }    

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var res = Resources.Load<GameObject>(e.resource.name);
            GameObject gameObject = null;
            try {
                gameObject = UnityEngine.Object.Instantiate(res);

            } catch (Exception) {
                Debug.Log("Cannot instantiate " + res + " (" + e.resource.name+")");
                continue;
            }
            
            Transform parent = GameController.Instance.gameObject.transform.Find(e.resource.container.ToString());
            if (parent == null) {
                Debug.Log("Parent not found for id: " + e.resource.container.ToString());
                continue;
            } else {
                gameObject.transform.parent = parent;
                if (e.hasView) {
                    Debug.Log("Removing previous GameObject");
                    e.RemoveView();
                }
                e.AddView(gameObject);
            }                            
        }
    }
}

