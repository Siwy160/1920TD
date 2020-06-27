using System;
using GamePlay.Data;
using UnityEngine;

namespace GamePlay
{
    public class TurretSpawner : MonoBehaviour
    {
        private TowerData _towerToSpawn;

        public TowerData TowerToSpawn { get => _towerToSpawn; set => _towerToSpawn = value; }

        public void SpawnTower(GameObject parent)
        {
            if (_towerToSpawn != null)
            {
                GameObject tower = Instantiate(_towerToSpawn.Prefab);
                //tower.transform.parent = parent.transform;
                tower.transform.position = parent.transform.position;
            }
        }

        internal void Restart()
        {
            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
            foreach (GameObject turret in turrets)
            {
                Destroy(turret);
            }
        }
    }
}