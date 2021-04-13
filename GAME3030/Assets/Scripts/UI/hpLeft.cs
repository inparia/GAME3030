using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpLeft : MonoBehaviour
{
    private TMPro.TextMeshProUGUI tMPro;
    // Start is called before the first frame update
    void Start()
    {
        tMPro = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tMPro.text = "HP : " + GameManager.Instance.playerHp;
    }
}
