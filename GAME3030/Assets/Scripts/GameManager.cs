using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StageLevel
{
    LEVELONE,
    LEVELTWO,
    LEVELTHREE,
    LEVELFOUR
}
[System.Serializable]
public class gameLevels
{
    public StageLevel stageLevel;
    public int levels;
    public int nextLevels;
    
}
public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    #endregion

    public bool spawnComplete;
    public bool gameStarted;
    public StageLevel gameStageLevel;
    public gameLevels[] gameLevel;
    // Start is called before the first frame update
    void Start()
    {
        
        gameReset();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
       if(gameLevel[0].nextLevels <= 0)
        {
            gameStageLevel = gameLevel[1].stageLevel;
        }
       if(gameLevel[1].nextLevels <= 0)
        {
            gameStageLevel = gameLevel[2].stageLevel;
        }
       if(gameLevel[3].nextLevels <= 0)
        {
            gameStageLevel = gameLevel[3].stageLevel;
        }
    }

    void gameReset()
    {
        gameStageLevel = gameLevel[0].stageLevel;
        spawnComplete = false;
        gameStarted = false;
        Cursor.visible = false;
    }

}
