using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    SLOW,
    DYNAMITE
}
public class UseSkill : MonoBehaviour
{
    public char skillKey;
    public float timeRemaining;
    public bool skillUsed;
    public GameObject cdObj, skillObj;
    public SkillType skillType;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 3;
        skillUsed = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!skillUsed && Input.GetKeyDown(skillKey.ToString()))
        {
            var skillObject = Instantiate(skillObj, player.transform.position, player.transform.rotation);
            if (skillType == SkillType.SLOW)
            {
                skillObject.tag = "SlowPlane";
                skillObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            }

            else if (skillType == SkillType.DYNAMITE)
            {
                skillObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }


            skillUsed = true;
        }

        if (skillUsed)
        {
            cdObj.SetActive(true);
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 3;
                skillUsed = false;
            }
        }
    }
}
