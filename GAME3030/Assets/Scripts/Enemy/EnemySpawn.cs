using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public float timeRemaining;
    private float originalTime;
    public int objSpawn, objTwoSpawn, objThreeSpawn, objFourSpawn;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        if (objSpawn != 5 && GameManager.Instance.stageLevel == StageLevel.LEVELONE)
        {
            spawnEnemy();
        }

        else if (objTwoSpawn != 10 && GameManager.Instance.stageLevel == StageLevel.LEVELTWO)
        {
            spawnEnemy();
        }
        else if (objThreeSpawn != 15 && GameManager.Instance.stageLevel == StageLevel.LEVELTHREE)
        {
            spawnEnemy();
        }

        else if (objFourSpawn != 20 && GameManager.Instance.stageLevel == StageLevel.LEVELFOUR)
        {
            spawnEnemy();
        }
    }

    public void spawnEnemy()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            var tempEnemy = Instantiate(enemy, transform.position, transform.rotation);
            timeRemaining = originalTime;
            if (GameManager.Instance.stageLevel == StageLevel.LEVELONE)
            {
                objSpawn++;
            }
            else if (GameManager.Instance.stageLevel == StageLevel.LEVELTWO)
            {
                objTwoSpawn++;
            }
            else if (GameManager.Instance.stageLevel == StageLevel.LEVELTHREE)
            {
                objThreeSpawn++;
            }
            else if (GameManager.Instance.stageLevel == StageLevel.LEVELFOUR)
            {
                objFourSpawn++;
            }
        }
            //if (!gameManager.spawnComplete)
            //{
            //    if (timeRemaining > 0)
            //    {
            //        timeRemaining -= Time.deltaTime;
            //    }
            //    else
            //    {
            //        timeRemaining = 3;
            //        return true;
            //    }
            //for (int i = 0; i < numtoSpawn; i++)
            //    {
            //        var tempEnemy = Instantiate(enemy, transform.position, transform.rotation);
            //        if (i == numtoSpawn - 1)
            //        {
            //            gameManager.spawnComplete = true;
            //        }
            //    }
            //}

    }
}
