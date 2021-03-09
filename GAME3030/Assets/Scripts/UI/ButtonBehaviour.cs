using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = false;
        GameManager.Instance.gameReset();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
