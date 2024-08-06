using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BillboardRotationScript : MonoBehaviour
{
    [SerializeField] GameObject[] billboardMeshes;

    Transform activeCamera;

    void Start()
    {
        activeCamera = Camera.main.transform;
        int activeBillboardIndex = Random.Range(0, billboardMeshes.Length);
        GameObject activeBillboard = billboardMeshes[activeBillboardIndex];
        activeBillboard.SetActive(true);
        activeBillboard.transform.localScale = Vector3.one * Random.Range(0.9f, 1.7f);        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targPosLevel = activeCamera.position;
        targPosLevel.y = transform.position.y;
        transform.LookAt(targPosLevel);
    }
}
