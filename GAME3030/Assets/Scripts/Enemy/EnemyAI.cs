﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position != player.transform.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }
        if(collision.gameObject.tag == "SlowPlane")
        {
            speed = 0.5f;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "SlowPlane")
        {
            speed = 1.0f;
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance.stageLevel == StageLevel.LEVELONE)
        {
            GameManager.Instance.levelOneEnemy--;
        }

        else if (GameManager.Instance.stageLevel == StageLevel.LEVELTWO)
        {
            GameManager.Instance.levelTwoEnemy--;
        }
        else if (GameManager.Instance.stageLevel == StageLevel.LEVELTHREE)
        {
            GameManager.Instance.levelThreeEnemy--;

        }

        else if (GameManager.Instance.stageLevel == StageLevel.LEVELFOUR)
        {
            GameManager.Instance.levelFourEnemy--;
        }
    }
}
