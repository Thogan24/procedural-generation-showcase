using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TreeConstructor : MonoBehaviour
{
    public GameObject Block;
    public Vector3 sampleSpawnPoint = new Vector3(0, 0, 0);
    public Vector3 sampleSpawnRotation = new Vector3(0, 0, 0);
    public int DestroyTime = 3;
    public int BlocksLeft = 1000;
    public int branchProbability = 20;
    private int branchChance = 0;
    public bool autoGenerateTrees = false;
    private float Timer = 4f;

    public float startingR = 0.0f; // 101
    public float startingG = 0.0f; // 67
    public float startingB = 0.0f; // 33

    public float startingRMod = 0.0f;
    public float startingGMod = 0.0f;
    public float startingBMod = 0.0f;

    public float rModAddition = 0.0f;
    public float gModAddition = 0.0f;
    public float bModAddition = 0.0f;

    public bool autoDestroy2 = false;
    public bool paused = false;

    public float lowRandomModifier = -10;
    public float highRandomModifier = 20;
    private void Update()
    {

        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(generateTree(sampleSpawnPoint, sampleSpawnRotation, 2, BlocksLeft, DestroyTime, startingR, startingG, startingB, startingRMod, startingGMod, startingBMod));
        }
        if (Input.GetKey("u"))
        {
            autoGenerateTrees = !autoGenerateTrees;
        }
        if (Input.GetKeyDown("space"))
        {
            if (paused == true)
            {
                paused = false;
            }
            else
            {
                paused = true;
            }
        }
        if (autoGenerateTrees)
        {
            if (!paused)
            {
                Timer += Time.deltaTime;
            }
            
            while(Timer >= 4.2f)
            {
                if (autoDestroy2)
                {
                    GameObject[] blocks = GameObject.FindGameObjectsWithTag("block");
                    for (int i = 0; i < blocks.Length; i++)
                    {
                        Destroy(blocks[i]);
                    }
                }
                StartCoroutine(generateTree(sampleSpawnPoint, sampleSpawnRotation, 2, BlocksLeft, DestroyTime, startingR, startingG, startingB, startingRMod, startingGMod, startingBMod));
                Timer = 0f;
            }
        }

    }

    IEnumerator generateTree(Vector3 spawnPoint, Vector3 spawnRotation, int blockHeight, int blocksLeft, int DestroyTimer, float r, float g, float b, float rMod, float gMod, float bMod)
    {
        // Debug.Log("Generating Tree...");
        branchChance = 0;
        

        while (blocksLeft > 0)
        {
            
            GameObject currentBlock = Instantiate(Block, spawnPoint + new Vector3(0, blockHeight / 2, 0), Quaternion.identity);            
            currentBlock.transform.localEulerAngles = spawnRotation;


            // Color Changing

            // Debug.Log(r + " " + g + " " + b);
            Color blockColor = new Color(r / 255.0f, g / 255.0f, b / 255.0f);
            Material mat = new Material(Shader.Find("Diffuse"));
            mat.color = blockColor;
            currentBlock.GetComponent<Renderer>().material = mat;

            
            r+=Random.Range(lowRandomModifier, highRandomModifier) + rMod;
            g+=Random.Range(lowRandomModifier, highRandomModifier) + gMod;
            b+=Random.Range(lowRandomModifier, highRandomModifier) + bMod;


            // Actual chance of branching gets higher every block 

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
                // Debug.Log("Branched");
                branch(spawnPoint, spawnRotation, blockHeight, blocksLeft, DestroyTimer, r, g, b, rMod, gMod, bMod);
                break;
            }
        }
        



        // Debug.Log("Tree Successfully Generated.");
    }

    void branch(Vector3 spawnPoint, Vector3 spawnRotation, int blockHeight, int blocksLeft, int DestroyTimer, float currentR, float currentG, float currentB, float currentRMod, float currentGMod, float currentBMod)
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
            StartCoroutine(generateTree(spawnPoint + branchVectorSpawnPoints, spawnRotation, blockHeight, blocksLeft / 2, DestroyTimer, currentR, currentG, currentB, currentRMod + rModAddition, currentGMod + gModAddition, currentBMod + bModAddition));
            StartCoroutine(generateTree(spawnPoint - branchVectorSpawnPoints, spawnRotation, blockHeight, blocksLeft / 2, DestroyTimer, currentR, currentG, currentB, currentRMod - rModAddition, currentGMod - gModAddition, currentBMod - bModAddition));
    }
}
