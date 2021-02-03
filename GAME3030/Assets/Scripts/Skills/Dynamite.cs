using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    public float timeRemaining;
    public bool destroyNearby;
    // Start is called before the first frame update
    void Start()
    {
        destroyNearby = false;
        timeRemaining = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            destroyNearby = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (destroyNearby)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
            }

            Destroy(gameObject);
        }
    }
}
