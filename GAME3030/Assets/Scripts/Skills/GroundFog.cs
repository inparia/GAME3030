using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundFog : MonoBehaviour
{

    public ParticleSystem particleSystem;
    private ParticleSystem particle;
    public Collider[] colliding;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7);
        particle = Instantiate(particleSystem, new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.identity) ;
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {

        colliding = Physics.OverlapSphere(transform.position, 6.0f);

        foreach (Collider hit in colliding)
        {

            if (hit && hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.GetComponent<EnemyAI>().enemyIdle = true;
            }
        }
    }
    void OnDestroy()
    {
        particle.GetComponent<DeleteParticle>().setDeleteTime(1);
        foreach (Collider hit in colliding)
        {

            if (hit && hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.GetComponent<EnemyAI>().enemyIdle = false;
            }
        }
    }
}
