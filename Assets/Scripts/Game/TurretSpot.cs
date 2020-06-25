using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpot : MonoBehaviour
{
    public Material selectedColor;
    private Turret turret = null;
    private Material initialColor;
    private Renderer spotRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spotRenderer = GetComponentInChildren<Renderer>();
        initialColor = spotRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void Clicked()
    {
        spotRenderer.material = selectedColor;
    }

    internal void Deselect()
    {
        spotRenderer.material = initialColor;
    }
}
