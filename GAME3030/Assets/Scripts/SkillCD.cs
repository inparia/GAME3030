using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCD : MonoBehaviour
{

    public float timeRemaining;
    public Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (GetComponentInParent<UseSkill>().skillUsed)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 
                GetComponentInParent<UseSkill>().timeRemaining/ GetComponentInParent<UseSkill>().givenTime, 
                gameObject.transform.localScale.z);

        }

        if(!GetComponentInParent<UseSkill>().skillUsed)
        {
        gameObject.transform.localScale = originalScale;
        timeRemaining = GetComponentInParent<UseSkill>().givenTime;
        gameObject.SetActive(false);
        }
    }

}
