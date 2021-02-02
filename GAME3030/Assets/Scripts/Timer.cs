using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timeRemaining = 3;

    void Update()
    {
        timerSet();
    }

    public bool timerSet()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 3;
            return true;
        }

        return false;
    }
}
