using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameManager gameManager;
    public float timeRemaining = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemy(5);
    }

    public void spawnEnemy(int numtoSpawn)
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            var tempEnemy = Instantiate(enemy, transform.position, transform.rotation);
            timeRemaining = 3;
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
