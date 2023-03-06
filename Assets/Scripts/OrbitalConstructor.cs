using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalConstructor : MonoBehaviour
{
    public GameObject Block;
    public Vector3 sampleSpawnPoint = new Vector3(0, 5, 0);
    public Vector3 sampleSpawnRotation = new Vector3(0, 0, 0);
    public int sampleDestroyTime = 3;
    public int sampleBlocksLeft = 50;

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(generateCircle(sampleSpawnPoint, sampleSpawnRotation, 2, sampleBlocksLeft, sampleDestroyTime));
        }
    }

    IEnumerator generateCircle(Vector3 spawnPoint, Vector3 spawnRotation, int blockHeight, int blocksLeft, int DestroyTimer)
    {
        Debug.Log("Generating Circle...");

        // Takes the circumference and divides it by 2pi
        float radius = (blocksLeft * blockHeight) / (2 * Mathf.PI);
        float angleIncrement = 360 / blocksLeft;
        for (int i = blocksLeft; i > 0; i--)
        {
            float xPos = Mathf.Sin(15) * radius;
            float zPos = radius - xPos;
            Vector3 position = new Vector3(xPos, 0, zPos);
            yield return new WaitForSeconds(3 / blocksLeft);
            Instantiate(Block, spawnPoint + position, Quaternion.identity);
        }
    }

    /*IEnumerator spawnBlock(Vector3 spawnPoint, Vector3 spawnRotation, int endPos, int DestroyTimer)
    {

    }*/
}