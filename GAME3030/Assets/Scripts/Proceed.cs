using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProceedToNextLevel()
    {
        if (gameManager.stageLevel == StageLevel.LEVELONE)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
            gameManager.stageLevel = StageLevel.LEVELTWO;
            gameManager.spawnComplete = false;
        }
    }
}
