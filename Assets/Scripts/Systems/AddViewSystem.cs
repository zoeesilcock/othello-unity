using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;

public class AddViewSystem : IReactiveSystem {
  public TriggerOnEvent trigger { get { return Matcher.Prefab.OnEntityAdded(); } }

  readonly Transform viewContainer = new GameObject("Views").transform;

  public void Execute(List<Entity> entities) {
    foreach (var entity in entities) {
      GameObject gameObject = Object.Instantiate(entity.prefab.gameObject);
      gameObject.transform.SetParent(viewContainer, false);
      entity.AddView(gameObject);
    }
  }
}
