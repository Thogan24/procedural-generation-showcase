using UnityEngine;

public class TreeConstructor : MonoBehaviour
{
    public GameObject Block;
    public Vector3 sampleSpawnPoint = new Vector3(0, 0, 0);
    public Vector3 sampleSpawnRotation = new Vector3(0, 0, 0);
    private void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            generateTree(sampleSpawnPoint, sampleSpawnRotation, 1, 2, 20);
        }
    }

    void generateTree(Vector3 spawnPoint, Vector3 spawnRotation, int blockSize, int blockHeight, int blocksLeft)
    {
        Debug.Log("Generating Tree...");
        GameObject firstBlock = Instantiate(Block, spawnPoint + new Vector3(0, blockHeight/2, 0), Quaternion.identity);
        firstBlock.transform.localEulerAngles = new Vector3(0, 0, 0);







        Debug.Log("Tree Successfully Generated.");
    }
}
