using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TurretSpotsController : MonoBehaviour
    {
        private List<TurretSpot> _spots = new List<TurretSpot>();

        public void Initialize(SpotListener listener)
        {
            Debug.Log("Set listener to turret spot");
            AddTurretsSpot();
            foreach (TurretSpot spot in _spots)
            {
                spot.Listener = listener;
            }
            Restart();
        }

        private void AddTurretsSpot()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Spot");
            foreach (GameObject gameObject in gameObjects)
            {
                _spots.Add(gameObject.GetComponent<TurretSpot>());
            }
        }

        public void Restart()
        {
            foreach (TurretSpot spot in _spots)
            {
                spot.IsSelected = false;
            }
        }
    }
}