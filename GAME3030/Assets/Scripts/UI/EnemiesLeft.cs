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
        if(GameManager.Instance.stageLevel == StageLevel.LEVELONE)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.levelOneEnemy.ToString();
        }
        else if (GameManager.Instance.stageLevel == StageLevel.LEVELTWO)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.levelTwoEnemy.ToString();
        }
        else if (GameManager.Instance.stageLevel == StageLevel.LEVELTHREE)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.levelThreeEnemy.ToString();
        }
        else if (GameManager.Instance.stageLevel == StageLevel.LEVELFOUR)
        {
            gameText.text = "Enemies Left : " + GameManager.Instance.levelFourEnemy.ToString();
        }
    }
}
