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
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        originalTime = timeRemaining;
        objToSpawn = new int[GameManager.Instance.gameLevel.Length];
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameManager.Instance.gameStageLevel)
        {
            case StageLevel.LEVELONE:
                if(objToSpawn[0] != GameManager.Instance.gameLevel[0].levels / 5)
                    spawnEnemy();
                 break;
            case StageLevel.LEVELTWO:
                if (objToSpawn[1] != GameManager.Instance.gameLevel[1].levels / 5)
                    spawnEnemy();
                break;
            case StageLevel.LEVELTHREE:
                if (objToSpawn[2] != GameManager.Instance.gameLevel[2].levels / 5)
                    spawnEnemy();
                break;
            case StageLevel.LEVELFOUR:
                if (objToSpawn[3] != GameManager.Instance.gameLevel[3].levels / 5)
                    spawnEnemy();
                break;
        }
        
        if (GameManager.Instance.gameLevel[3].levels == 0 && GameManager.Instance.gameStageLevel == StageLevel.LEVELFOUR)
        {
            Cursor.visible = true;
            button.gameObject.SetActive(true);
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
            switch (GameManager.Instance.gameStageLevel)
            {
                case StageLevel.LEVELONE:
                    objToSpawn[0]++;
                    break;
                case StageLevel.LEVELTWO:
                    objToSpawn[1]++;
                    break;
                case StageLevel.LEVELTHREE:
                    objToSpawn[2]++;
                    break;
                case StageLevel.LEVELFOUR:
                    objToSpawn[3]++;
                    break;
            }
        }

    }
}
