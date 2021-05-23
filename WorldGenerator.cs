using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public float MAX_WIDTH_X = 100f;
    public float MAX_WIDTH_Z = 256f;
    
    private int Generated_Amount = 0;
    private int CurrentWidthZ = 0;

    private List<Transform> chunksTransform = new List<Transform>();

    private void FixedUpdate()
    {
        if(CurrentWidthZ <= 256)
        {
            GenerateChunks();
        }
    }

    private void GenerateChunks()
    {
        for (int i = 0; i < MAX_WIDTH_X; i++)
        {
            GameObject worldTile = GameObject.CreatePrimitive(PrimitiveType.Plane);
            worldTile.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            worldTile.tag = "Chunk";
            worldTile.isStatic = true;
            worldTile.GetComponent<MeshRenderer>().enabled = false;

            chunksTransform.Add(worldTile.transform);

            if (Generated_Amount > 1)
            {
                worldTile.transform.position = new Vector3(chunksTransform[Generated_Amount - 1].position.x + 10f, 0f, CurrentWidthZ * 10f);
            }

            Generated_Amount += 1;
        }
        Generated_Amount = 0;
        CurrentWidthZ += 1;
    }
}
