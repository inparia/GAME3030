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

    public StageLevel stageLevel;
    public bool spawnComplete;
    public bool gameStarted;
    public int levelOneEnemy, levelTwoEnemy, levelThreeEnemy, levelFourEnemy;
    // Start is called before the first frame update
    void Start()
    {
        stageLevel = StageLevel.LEVELONE;
        spawnComplete = false;
        gameStarted = false;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
       if(levelOneEnemy <= 0)
        {
            stageLevel = StageLevel.LEVELTWO;
        }
       if(levelTwoEnemy <= 0)
        {
            stageLevel = StageLevel.LEVELTHREE;
        }
       if(levelThreeEnemy <= 0)
        {
            stageLevel = StageLevel.LEVELFOUR;
        }
    }
}
