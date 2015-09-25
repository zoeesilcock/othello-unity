using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class RenderRotationSystem : IReactiveSystem {
  public TriggerOnEvent trigger { get { return Matcher.Disc.OnEntityAdded(); } }

  readonly Transform viewContainer = new GameObject ("Views").transform;

  public void Execute (List<Entity> entities){
    foreach (var entity in entities) {
      if (entity.disc.isBlack) {
        entity.view.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0);
      } else {
        entity.view.gameObject.transform.localRotation = Quaternion.Euler(270, 0, 0);
      }
    }
  }
}
