using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public float timeRemaining;
    private float originalTime;
    public int[] objToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeRemaining;
        objToSpawn = new int[GameManager.Instance.gameLevel.Length];
    }

    // Update is called once per frame
    void Update()
    {
            if (objToSpawn[GameManager.Instance.gameStageLevel] != GameManager.Instance.gameLevel[GameManager.Instance.gameStageLevel].levels / 5)
                spawnEnemy();
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
            objToSpawn[GameManager.Instance.gameStageLevel]++;
        }

    }
}
