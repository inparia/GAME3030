using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUI : MonoBehaviour
{
    private TMPro.TextMeshProUGUI tMPro;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        tMPro = GetComponent<TMPro.TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        tMPro.text = "X " + player.GetComponent<CharacterShoot>().bulletCount;
    }
}
