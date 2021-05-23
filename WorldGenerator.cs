using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public float MAX_WIDTH = 100f;
    public float MAX_HEIGTH = 256f;

    private int Generated_Amount = 0;

    private List<Transform> chunksTransform = new List<Transform>();

    private int indexer = 0;

    private void FixedUpdate()
    {
        if(indexer <= 256)
        {
            GenerateChunks();
        }
    }

    private void GenerateChunks()
    {
        for (int i = 0; i < MAX_WIDTH; i++)
        {
            GameObject worldTile = GameObject.CreatePrimitive(PrimitiveType.Plane);
            worldTile.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            worldTile.tag = "Chunk";
            worldTile.isStatic = true;
            worldTile.GetComponent<MeshRenderer>().enabled = false;

            chunksTransform.Add(worldTile.transform);

            if (Generated_Amount > 1)
            {
                worldTile.transform.position = new Vector3(chunksTransform[Generated_Amount - 1].position.x + 10f, 0f, indexer * 10f);
            }

            Generated_Amount += 1;
        }
        Generated_Amount = 0;
        indexer += 1;
    }
}
