using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : IReactiveSystem {
  public TriggerOnEvent trigger { get { return Matcher.Position.OnEntityAdded (); } }

  readonly Transform viewContainer = new GameObject ("Views").transform;

  public void Execute (List<Entity> entities){
    foreach (var entity in entities) {
      var gridPosition = entity.position;

      entity.view.gameObject.transform.position = new Vector3(-3.5f + gridPosition.x, 0.1f, -3.5f + gridPosition.y);
    }
  }
}
