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
                TurretSpot turretSpot = gameObject.GetComponent<TurretSpot>();
                turretSpot.Initialize();
                _spots.Add(turretSpot);
            }
        }

        public void Restart()
        {
            foreach (TurretSpot spot in _spots)
            {
                spot.IsSelected = false;
            }
        }

        public void DisableSpots()
        {
            foreach (TurretSpot spot in _spots)
            {
                if (spot != null)
                {
                    spot.Hide();
                }
            }
        }

        public void EnableSpots()
        {
            foreach (TurretSpot spot in _spots)
            {
                if (spot != null)
                {
                    spot.Show();
                }
            }
        }
    }
}