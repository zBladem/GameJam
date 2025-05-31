using System.Collections.Generic;
using UnityEngine;

public class PlatformManagerInverted : MonoBehaviour
{
    private Transform player;
    private Vector3 nextPosition;
    public int platformsAhead = 2;
    public GameObject prefabPlatform;
    public float platformLength = 10f;
    private List<GameObject> platformList = new List<GameObject>();
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextPosition = Vector3.zero;
        for (int i = 0; i < platformsAhead + 1; i++)
        {
            PlatformGenerator();
        }
    }
    void Update()
    {
        if (-player.position.z - (platformsAhead * platformLength) > nextPosition.z + platformLength)
        {
            PlatformGenerator();
        }
    }
    void PlatformGenerator()
    {
        GameObject newPlatform = Instantiate(prefabPlatform, nextPosition, Quaternion.identity);
        platformList.Add(newPlatform);
        nextPosition += new Vector3(0, 0, platformLength);
        if (platformList.Count > platformsAhead + 2)
        {
            Destroy(platformList[0]);
            platformList.RemoveAt(0);
        }
    }
}
