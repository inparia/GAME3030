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
    // Start is called before the first frame update
    void Start()
    {
        stageLevel = StageLevel.LEVELONE;
        spawnComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
