using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public bool dead, enemyIdle, enemyAttack, playerInRange;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    public AudioSource zombieDeath;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        dead = false;
        enemyIdle = false;
        enemyAttack = false;
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gamePaused)
        {
            if (enemyIdle)
            {
                navMeshAgent.isStopped = true;
                animator.SetBool("isIdle", true);
            }
            else if (!enemyIdle && !dead)
            {
                navMeshAgent.isStopped = false;
                animator.SetBool("isIdle", false);
            }

            if (gameObject.transform.position != player.transform.position && !dead && !enemyIdle && !enemyAttack)
            {
                navMeshAgent.destination = player.transform.position;
                transform.LookAt(player.transform);
            }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            if(!enemyAttack)
                StartCoroutine(enemyAttackAnimation(2f));
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            if(!enemyAttack)
                StartCoroutine(enemyAttackAnimation(2f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    public void killEnemy()
    {
        navMeshAgent.isStopped = true;
        if(!dead && !enemyAttack)
            zombieDeath.Play();
        Destroy(gameObject, 2);
        animator.SetBool("isDead", true);
        dead = true;
        
    }
    void OnDestroy()
    {
        GameManager.Instance.gameLevel[GameManager.Instance.gameStageLevel].nextLevels--;
    }

    public IEnumerator enemyAttackAnimation(float animationLength)
    {
        navMeshAgent.isStopped = true;
        enemyAttack = true;
        animator.SetBool("isAttack", true);


        yield return new WaitForSeconds(animationLength);


        if (playerInRange)
        {
            player.GetComponent<Player>().loseHp();
        }

        animator.SetBool("isAttack", false);
        enemyAttack = false;
        navMeshAgent.isStopped = false;
    }
}
