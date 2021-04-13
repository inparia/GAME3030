using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class gameLevels
{
    public int stageLevel;
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

    public int gameStageLevel;
    public gameLevels[] gameLevel;
    public int playerHp;
    public bool gamePaused;
    // Start is called before the first frame update
    void Start()
    {
        gameReset();
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((gameLevel[gameLevel.Length - 1].nextLevels == 0 && gameStageLevel == gameLevel.Length - 1))
        {
            SceneManager.LoadScene("Win");
            Cursor.visible = true;
            gameReset();
        }

        else if (gameLevel[gameStageLevel].nextLevels <= 0 && gameStageLevel <= gameLevel.Length - 1)
        {
            gameStageLevel++;
        }
    }

    public void gameReset()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < gameLevel.Length; i++)
        {
            gameLevel[i].nextLevels = gameLevel[i].levels;
        }
        gameStageLevel = gameLevel[0].stageLevel;
        playerHp = 5;
        gamePaused = false;

    }
    public void delayScene(float delay, string SceneName)
    {
        StartCoroutine(LoadLevelAfterDelay(delay, SceneName));
    }
    IEnumerator LoadLevelAfterDelay(float delay, string SceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
    }
}
