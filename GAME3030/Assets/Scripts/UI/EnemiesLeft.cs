using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemiesLeft : MonoBehaviour
{

    private Text gameText;
    // Start is called before the first frame update
    void Start()
    {
        gameText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameStageLevel == StageLevel.LEVELONE)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.gameLevel[0].nextLevels;
        }
        else if (GameManager.Instance.gameStageLevel == StageLevel.LEVELTWO)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.gameLevel[1].nextLevels;
        }
        else if (GameManager.Instance.gameStageLevel == StageLevel.LEVELTHREE)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.gameLevel[2].nextLevels;
        }
        else if (GameManager.Instance.gameStageLevel == StageLevel.LEVELFOUR)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.gameLevel[3].nextLevels;
        }
    }
}
