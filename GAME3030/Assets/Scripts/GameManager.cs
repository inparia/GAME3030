using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageLevel
{
    LEVELONE,
    LEVELTWO
}

public class GameManager : MonoBehaviour
{
    public StageLevel stageLevel;
    public bool spawnComplete;
    public bool gameStarted;
    public bool dontSpawn;
    // Start is called before the first frame update
    void Start()
    {
        stageLevel = StageLevel.LEVELONE;
        spawnComplete = false;
        gameStarted = false;
        dontSpawn = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
