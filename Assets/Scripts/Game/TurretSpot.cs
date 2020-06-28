using Game;
using UnityEngine;

public class TurretSpot : MonoBehaviour
{
    public Material selectedColor;
    private Turret turret = null;
    private Material initialColor;
    private Renderer spotRenderer;
    private SpotListener _listener;
    private bool isSelected = false;
    public SpotListener Listener { set => _listener = value; }
    public bool IsSelected { get => isSelected; set => isSelected = value; }

    public void Initialize()
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
        Debug.Log("Spot selected");

        if (_listener != null)
        {
            _listener.OnSpotSelected(this);
        }

    }

    internal void Deselect()
    {
        spotRenderer.material = initialColor;
    }

    public void Hide()
    {
        if (spotRenderer != null)
        {
            spotRenderer.enabled = false;
        }
    }

    public void Show()
    {
        if (spotRenderer != null)
        {
            spotRenderer.enabled = true;
        }
    }
}
