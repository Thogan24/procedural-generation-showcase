using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TreeConstructor : MonoBehaviour
{
    public GameObject Block;
    public Vector3 sampleSpawnPoint = new Vector3(0, 0, 0);
    public Vector3 sampleSpawnRotation = new Vector3(0, 0, 0);
    public int sampleDestroyTime = 3;
    public int sampleBlocksLeft = 50;
    public int branchProbability = 20;
    private int branchChance = 0;
    public bool autoGenerateTrees = false;
    private float Timer = 4f;
    private void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(generateTree(sampleSpawnPoint, sampleSpawnRotation, 2, sampleBlocksLeft, sampleDestroyTime));
        }
        if (Input.GetKey("u"))
        {
            autoGenerateTrees = !autoGenerateTrees;
        }
        if (autoGenerateTrees)
        {
            Timer += Time.deltaTime;
            while(Timer >= 4f)
            {
                StartCoroutine(generateTree(sampleSpawnPoint, sampleSpawnRotation, 2, sampleBlocksLeft, sampleDestroyTime));
                Timer = 0f;
            }
        }

    }

    IEnumerator generateTree(Vector3 spawnPoint, Vector3 spawnRotation, int blockHeight, int blocksLeft, int DestroyTimer)
    {
        Debug.Log("Generating Tree...");
        branchChance = 0;
        float r = 85;
        float g = 75;
        float b = 55;

        while (blocksLeft > 0)
        {
            
            GameObject currentBlock = Instantiate(Block, spawnPoint + new Vector3(0, blockHeight / 2, 0), Quaternion.identity);            
            currentBlock.transform.localEulerAngles = spawnRotation;

            
            //currentBlock.GetComponent<MeshRenderer>().material.color = Color.green;

            r++;
            g++;
            b++;

            branchChance += branchProbability;
            blocksLeft--;

            float xAxisRotationChange = Random.Range(-21, 21);
            float zAxisRotationChange = Random.Range(-21, 21);
            spawnPoint += new Vector3(-spawnRotation.z / 20, blockHeight, spawnRotation.x / 20);
            spawnRotation += new Vector3(xAxisRotationChange, 0, zAxisRotationChange);

            yield return new WaitForSeconds(0.1f);

            if (DestroyTimer > 0)
            {
                Destroy(currentBlock, DestroyTimer);
            }
            if (Random.Range(1, 101) <= branchChance)
            {
                Debug.Log("Branched");
                branch(spawnPoint, spawnRotation, blockHeight, blocksLeft, DestroyTimer);
                break;
            }
        }
        



        Debug.Log("Tree Successfully Generated.");
    }

    void branch(Vector3 spawnPoint, Vector3 spawnRotation, int blockHeight, int blocksLeft, int DestroyTimer)
    {
            int xAxisBranch = Random.Range(0, 2);
            int zAxisBranch;
            if (xAxisBranch == 0)
            {
                zAxisBranch = 1;
            }
            else
            {
                zAxisBranch = Random.Range(0, 2);
            }
            Vector3 branchVectorSpawnPoints = new Vector3(xAxisBranch, 0, zAxisBranch);
            StartCoroutine(generateTree(spawnPoint + branchVectorSpawnPoints, spawnRotation, blockHeight, blocksLeft / 2, DestroyTimer));
            StartCoroutine(generateTree(spawnPoint - branchVectorSpawnPoints, spawnRotation, blockHeight, blocksLeft / 2, DestroyTimer));
    }
}
