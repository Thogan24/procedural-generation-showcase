using UnityEngine;

public class TreeConstructor : MonoBehaviour
{
    public GameObject Block;
    public Vector3 sampleSpawnPoint = new Vector3(0, 0, 0);
    public Vector3 sampleSpawnRotation = new Vector3(0, 0, 0);
    public int branchProbability = 20;
    private int branchChance = 0;
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
        branchChance = 0;

        while(blocksLeft > 0)
        {
            spawnPoint += new Vector3(0, blockHeight, 0);
            GameObject currentBlock = Instantiate(Block, spawnPoint + new Vector3(0, blockHeight / 2, 0), Quaternion.identity);
            currentBlock.transform.localEulerAngles = new Vector3(0, 0, 0);
            branchChance += branchProbability;
            blocksLeft--;
            if (Random.Range(1, 101) <= branchChance)
            {
                Debug.Log("Branched");
                branch(blocksLeft);
                break;
            }
        }
        



        Debug.Log("Tree Successfully Generated.");
    }

    void branch(int blocksLeft)
    {
        //generateTree(, , , ,blocksLeft / 2);
    }
}
