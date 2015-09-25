using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
  void Update() {
    if (Input.GetButtonDown("Fire1")) {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, 100)) {
        int gridX = (int)-Mathf.Ceil(hit.point.x - 4);
        int gridY = (int)Mathf.Ceil(hit.point.z + 3);

        PoolExtension.CreateDiscEntity(Pools.pool, gridX, gridY, false);
      }
    }
  }
}
