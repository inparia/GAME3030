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
            if(GetComponentInParent<UseSkill>().timeRemaining < 2)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 0.6f, gameObject.transform.localScale.z);
            }

            if(GetComponentInParent<UseSkill>().timeRemaining < 1)
            {
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, 0.3f, gameObject.transform.localScale.z);
            }

            }
            if(!GetComponentInParent<UseSkill>().skillUsed)
            {
                gameObject.transform.localScale = originalScale;
                timeRemaining = 3;
                gameObject.SetActive(false);
            }
 
    }
}
