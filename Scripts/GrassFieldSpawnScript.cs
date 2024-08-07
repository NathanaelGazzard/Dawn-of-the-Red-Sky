using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassFieldSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject[] grassPrefabs;
    MeshFilter spawnerMesh;


    void Start()
    {
        spawnerMesh = GetComponent<MeshFilter>();

        Vector3[] spawnPoints = spawnerMesh.mesh.vertices;
        HashSet<Vector3> uniqueSpawnPoints = new HashSet<Vector3>();

        foreach (Vector3 spawnPoint in spawnPoints)
        {
            Vector3 worldSpawnPoint = spawnerMesh.transform.TransformPoint(spawnPoint + Vector3.down * .1f);

            if (uniqueSpawnPoints.Add(worldSpawnPoint))
            {
                int i = Random.Range(0, grassPrefabs.Length);
                GameObject newGrass = Instantiate(grassPrefabs[i], transform);
                newGrass.transform.position = worldSpawnPoint;
            }
        }
    }
}
