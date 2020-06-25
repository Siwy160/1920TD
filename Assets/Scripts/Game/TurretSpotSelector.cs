using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpotSelector : MonoBehaviour
{
    public GameObject turretSpotParent;

    private TurretSpot[] turretSpots;

    // Start is called before the first frame update
    void Start()
    {
        turretSpots = turretSpotParent.GetComponentsInChildren<TurretSpot>();
        Debug.Log("Turret spots: " + turretSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycast;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycast))
            {
                foreach (TurretSpot turretSpot in turretSpots)
                {
                    if (turretSpot.transform == raycast.transform)
                    {
                        turretSpot.Clicked();
                    }
                    else
                    {
                        turretSpot.Deselect();
                    }
                }
            }
        }
    }
}
