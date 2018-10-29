using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    int towerNum = 0;

    public void AddTower (TowerBase towerBase) {
        towerNum = GetComponentsInChildren<Tower>().Length;

        if (towerNum < towerLimit) {
            CreateTower(towerBase);
        } else {
            MoveTower(towerBase);
        }
    }

    void CreateTower (TowerBase towerBase) {
        Instantiate(towerPrefab, towerBase.transform.position, Quaternion.identity, towerBase.transform.parent);
        towerBase.isPlaceable = false;
    }

    void MoveTower (TowerBase towerBase) {
        Debug.Log("Max Towers reached");
    }
}
