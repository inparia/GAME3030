using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpLeft : MonoBehaviour
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
        gameText.text = "HP : " + GameManager.Instance.playerHp;
    }
}
