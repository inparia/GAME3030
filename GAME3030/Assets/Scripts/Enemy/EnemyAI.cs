using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public bool dead;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position != player.transform.position && !dead)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
            transform.LookAt(player.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            killEnemy();
            Destroy(collision.gameObject);
            
        }
        if(collision.gameObject.tag == "SlowPlane")
        {
            GetComponent<NavMeshAgent>().speed = 0.5f;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "SlowPlane")
        {
            GetComponent<NavMeshAgent>().speed = 1.0f;
        }
    }
    public void killEnemy()
    {
        GetComponent<NavMeshAgent>().isStopped = true;
        Destroy(gameObject, 2);
        animator.SetBool("isDead", true);
        dead = true;
    }
    private void OnDestroy()
    {
        switch(GameManager.Instance.stageLevel)
        {
            case StageLevel.LEVELONE:
                GameManager.Instance.levelOneEnemy--;
                break;
            case StageLevel.LEVELTWO:
                GameManager.Instance.levelTwoEnemy--;
                break;
            case StageLevel.LEVELTHREE:
                GameManager.Instance.levelThreeEnemy--;
                break;
            case StageLevel.LEVELFOUR:
                GameManager.Instance.levelFourEnemy--;
                break;
        }
    }
}
