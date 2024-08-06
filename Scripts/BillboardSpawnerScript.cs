using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject billboardPrefab;
    [SerializeField] MeshFilter spawnerTerrain;

    bool skipVertex = true;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] spawnPoints = spawnerTerrain.mesh.vertices;
        HashSet<Vector3> uniqueSpawnPoints = new HashSet<Vector3>();

        foreach (Vector3 spawnPoint in spawnPoints)
        {
            // Transform the local vertex position to world position
            Vector3 worldSpawnPoint = spawnerTerrain.transform.TransformPoint(spawnPoint);

            // Skip every other vertex
            skipVertex = !skipVertex;
            if (skipVertex)
            {
                //continue;
            }

            // Check if the point is already used
            if (uniqueSpawnPoints.Add(worldSpawnPoint))
            {
                GameObject newBillboard = Instantiate(billboardPrefab, transform);
                newBillboard.transform.position = worldSpawnPoint;
            }
        }
    }
}
