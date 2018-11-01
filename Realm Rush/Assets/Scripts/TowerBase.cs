using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour {

    public bool isPlaceable = true;

    void OnMouseOver () {
        if (Input.GetMouseButtonDown(0)) {
            if (isPlaceable) {
                GetComponentInParent<TowerFactory>().AddTower(this);
            }
        }
    }
}
