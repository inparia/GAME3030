using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public bool dead, enemyIdle;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        dead = false;
        enemyIdle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyIdle)
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            animator.SetBool("isIdle", true);
        }
        else if(!enemyIdle && !dead)
        {
            GetComponent<NavMeshAgent>().isStopped = false;
            animator.SetBool("isIdle", false);
        }

        if(gameObject.transform.position != player.transform.position && !dead && !enemyIdle)
        {
            GetComponent<NavMeshAgent>().destination = player.transform.position;
            transform.LookAt(player.transform);
        }
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            killEnemy();

            Destroy(collision.gameObject);

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
        switch(GameManager.Instance.gameStageLevel)
        {
            case StageLevel.LEVELONE:
                GameManager.Instance.gameLevel[0].nextLevels--;
                break;
            case StageLevel.LEVELTWO:
                GameManager.Instance.gameLevel[1].nextLevels--;
                break;
            case StageLevel.LEVELTHREE:
                GameManager.Instance.gameLevel[2].nextLevels--;
                break;
            case StageLevel.LEVELFOUR:
                GameManager.Instance.gameLevel[3].nextLevels--;
                break;
        }
    }
}
