using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    int towerNum = 0;
    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower (TowerBase towerBase) {
        towerNum = towerQueue.Count;

        if (towerNum < towerLimit) {
            CreateTower(towerBase);
        } else {
            MoveTower(towerBase);
        }
    }

    void CreateTower (TowerBase towerBase) {
        towerBase.isPlaceable = false;

        Tower newTower = Instantiate(towerPrefab, towerBase.transform.position, Quaternion.identity, towerParentTransform);
        newTower.towerBase = towerBase;

        towerQueue.Enqueue(newTower);
    }

    void MoveTower (TowerBase towerBase) {
        towerBase.isPlaceable = false;

        Tower oldTower = towerQueue.Dequeue();
        oldTower.towerBase.isPlaceable = true;
        oldTower.towerBase = towerBase;
        oldTower.transform.position = towerBase.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
