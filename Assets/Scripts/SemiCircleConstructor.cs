using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiCircleConstructor : MonoBehaviour
{
    public GameObject Block;
    public Vector3 sampleSpawnPoint = new Vector3(0, 5, 0);
    public int sampleDestroyTime = 3;
    public int sampleSize = 5;



    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            StartCoroutine(generateSemiCircle(sampleSpawnPoint, 2, sampleSize, sampleDestroyTime));
        }
    }

    IEnumerator generateSemiCircle(Vector3 spawnPoint, int blockHeight, int size, int DestroyTimer)
    {
        Debug.Log("Generating SemiCircle...");
        // BlockHeight / sampleSize
        Instantiate(Block, spawnPoint - new Vector3(0, blockHeight/size, 0), Quaternion.identity);

        for (int i = 2; i <= size; i++)
        {
            Instantiate(Block, spawnPoint - new Vector3(0, blockHeight / size, 0), Quaternion.identity);

            int numBlocks = i * 4;
            int xOutFromOrigin = 0;
            int zOutFromOrigin = numBlocks / 4;
            bool xMaxReached = false;
            bool xMinReached = false;
            bool zMinReached = false;

            for (int j = 0; j < numBlocks; j++)
            {
                if (xOutFromOrigin <= (numBlocks / 4) && !xMaxReached)
                {
                    xOutFromOrigin += 1;
                }
                else if (xOutFromOrigin >= -(numBlocks / 4) && xMinReached)
                {
                    xOutFromOrigin += 1;
                }
                else
                {
                    xMaxReached = true;
                    xOutFromOrigin -= 1;
                }
                if (xOutFromOrigin == -(numBlocks / 4))
                {
                    xMinReached = true;
                }



                // -1
                if (zOutFromOrigin >= -(numBlocks / 4) && !zMinReached)
                {
                    zOutFromOrigin -= 1;
                }
                else
                {
                    zMinReached = true;
                    zOutFromOrigin++;
                }
                // Add to Array
                
                GameObject currentBlock = Instantiate(Block, spawnPoint + new Vector3(xOutFromOrigin, blockHeight / size, zOutFromOrigin), Quaternion.identity);
                if (DestroyTimer > 0)
                {
                    Destroy(currentBlock, DestroyTimer);
                }
                Debug.Log(xOutFromOrigin);
            }



            yield return new WaitForSeconds(3f / (float) size);
        }

        
    }


}
