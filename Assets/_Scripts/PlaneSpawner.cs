using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _planes;
    public static bool CanSpawnPlane;

    private void Start()
    {
        CanSpawnPlane = true;
        SpawnRandomPlane();
    }

    private void SpawnRandomPlane()
    {
        int randomPlane = Random.Range(0, _planes.Length);
        GameObject newPlane = Instantiate(_planes[randomPlane]);
        newPlane.transform.position = new Vector2(15, 0);
        CanSpawnPlane = false;
    }

    private void Update()
    {
        if (CanSpawnPlane)
        {
            SpawnRandomPlane();
        }
    }
}
