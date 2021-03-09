using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dynamite : MonoBehaviour
{
    public float timeRemaining;
    public TextMesh text;
    public ParticleSystem particleSystem;
    private ParticleSystem particle;
    public Collider[] colliding;
    public AudioSource explosion, tempAudio;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        timeRemaining = 5.0f;
        particle = Instantiate(particleSystem, transform.position, Quaternion.identity);
        tempAudio = Instantiate(explosion, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        colliding = Physics.OverlapSphere(transform.position, 2.0f);

        if (timeRemaining > 0)
        {
            
            timeRemaining -= Time.deltaTime;
        }
        else
        {
        }

        text.text = ((int)timeRemaining + 1).ToString();
    }


    void OnDestroy()
    {
        
        particle.Play();
        tempAudio.Play();
        particle.GetComponent<DeleteParticle>().setDeleteTime(1);
        tempAudio.GetComponent<DeleteParticle>().setDeleteTime(1);
        foreach (Collider hit in colliding)
        {

            if (hit && hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.GetComponent<EnemyAI>().killEnemy();
            }
        }
    }
}
