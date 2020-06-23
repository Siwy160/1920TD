using System;
using Game.Assets.Scripts.Menu;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private CloudData[] clouds;

    [SerializeField]
    private float cloudStep = 1f;

    private readonly System.Random _random = new System.Random();

    void Start()
    {
        SpawnClouds();
    }

    private void SpawnClouds()
    {
        foreach (var cloud in clouds)
        {
            GameObject cloudObject = Instantiate(cloud.Prefab);
            cloudObject.transform.position = GetStartPosition(cloud);
            cloud.Object = cloudObject;
        }
    }

    private Vector3 GetStartPosition(CloudData cloud)
    {
        var x = cloud.RangeX.Start;
        var y = cloud.Y;
        var z = _random.Next(cloud.RangeZ.End, cloud.RangeZ.Start);
        return new Vector3(x, y, z);
    }

    void Update()
    {
        MoveClouds();
    }

    private void MoveClouds()
    {
        foreach (var cloud in clouds)
        {
            GameObject cloudObject = cloud.Object;
            if (cloudObject != null)
            {
                if (cloudObject.transform.position.x <= cloud.RangeX.End)
                {
                    cloudObject.transform.position = GetStartPosition(cloud);
                }
                var cloudPosition = cloudObject.transform.position;
                cloudObject.transform.position = new Vector3(cloudPosition.x - (cloudStep * Time.deltaTime), cloudPosition.y, cloudPosition.z);
            }
        }
    }
}
