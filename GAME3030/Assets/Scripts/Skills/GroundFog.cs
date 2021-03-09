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
        particle = Instantiate(particleSystem, transform.position, Quaternion.identity) ;
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {

        colliding = Physics.OverlapSphere(transform.position, 10.0f);

    }
    void OnDestroy()
    {
        particle.GetComponent<DeleteParticle>().setDeleteTime(1);
    }
}
