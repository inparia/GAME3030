using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public bool dead, enemyIdle, enemyAttack;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        dead = false;
        enemyIdle = false;
        enemyAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyIdle)
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("isIdle", true);
        }
        else if(!enemyIdle && !dead)
        {
            navMeshAgent.isStopped = false;
            animator.SetBool("isIdle", false);
        }

        if(gameObject.transform.position != player.transform.position && !dead && !enemyIdle && !enemyAttack)
        {
            navMeshAgent.destination = player.transform.position;
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

        if (collision.gameObject.tag == "Player")
        {
            navMeshAgent.isStopped = true;
            enemyAttack = true;
            animator.SetBool("isAttack", true);
            Destroy(gameObject, 2.7f);
        }
    }


    public void killEnemy()
    {
        navMeshAgent.isStopped = true;
        Destroy(gameObject, 2);
        animator.SetBool("isDead", true);
        dead = true;
    }
    void OnDestroy()
    {
        GameManager.Instance.gameLevel[GameManager.Instance.gameStageLevel].nextLevels--;
        if(enemyAttack)
        {
            GameManager.Instance.playerHp--;
        }
    }
}
