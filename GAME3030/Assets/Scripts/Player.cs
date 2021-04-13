using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int hp;
    public AudioSource playerHurt;
    // Start is called before the first frame update
    void Start()
    {
        hp = GameManager.Instance.playerHp;
    }

    // Update is called once per frame
    void Update()
    {
        hp = GameManager.Instance.playerHp;

    }

    public void loseHp()
    {
        if (!GetComponent<CharacterMovement>().isDead)
        {
            GameManager.Instance.playerHp--;
            playerHurt.Play();
        }
    }
}
