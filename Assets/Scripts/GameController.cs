using UnityEngine;
using System.Collections;
using Entitas;

public class GameController : MonoBehaviour {
  public GameObject _discPrefab;

  private Systems systems;
  private Pool pool;

  void Start() {
    pool = new Pool(ComponentIds.TotalComponents);

    systems = new Systems()
      .Add(pool.CreateSystem<AddViewSystem>())
      .Add(pool.CreateSystem<RenderPositionSystem>())
      .Add(pool.CreateSystem<RenderRotationSystem>());

    AddInitialDiscs();
  }

  void Update() {
    systems.Execute();
  }

  void AddInitialDiscs() {
    PoolExtension.CreateDiscEntity(pool, 3, 4, true);
    PoolExtension.CreateDiscEntity(pool, 4, 3, true);
    PoolExtension.CreateDiscEntity(pool, 4, 4);
    PoolExtension.CreateDiscEntity(pool, 3, 3);
  }
}
