using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _planes;

    private void Start()
    {
        StartCoroutine(SpawnRandomPlane());
    }

    private IEnumerator SpawnRandomPlane()
    {
        while (true)
        {
            int randomPlane = Random.Range(0, _planes.Length);
            GameObject newPlane = Instantiate(_planes[randomPlane]);
            newPlane.transform.position = new Vector2(15, 0);
            yield return new WaitForSeconds(10f);
        }
    }
}
