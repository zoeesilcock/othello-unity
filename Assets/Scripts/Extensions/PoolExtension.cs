using UnityEngine;
using Entitas;

public static class PoolExtension {
  public static Entity CreateDiscEntity(this Pool pool, int x, int y, bool isBlack = false) {
    return pool.CreateEntity()
      .AddPosition(x, y)
      .AddDisc(isBlack)
      .AddPrefab((GameObject)Resources.Load("Disc"));
  }
}
