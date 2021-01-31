using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.stageLevel == StageLevel.LEVELONE)
        {
            spawnEnemy(5);
        }

        if (gameManager.stageLevel == StageLevel.LEVELTWO)
        {
            spawnEnemy(10);
        }

        if (Input.GetKeyDown("f"))
        {
            Instantiate(enemy, Random.insideUnitSphere * 9 + transform.position, Random.rotation);
        }
    }

    public void spawnEnemy(int numtoSpawn)
    {
            if (!gameManager.spawnComplete)
            {
                for (int i = 0; i < numtoSpawn; i++)
                {
                    var tempEnemy = Instantiate(enemy, Random.insideUnitSphere * 9 + transform.position, transform.rotation);
                    if (i == numtoSpawn - 1)
                    {
                        gameManager.spawnComplete = true;
                    }
                }
        }

    }
}
