﻿using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    public void Awake()
    {
        waypoints = new Transform[transform.childCount];
        Debug.Log("Waypoints: " + waypoints.Length);
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
