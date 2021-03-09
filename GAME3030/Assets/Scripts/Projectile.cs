using UnityEngine;

/// <summary>
/// The class definition for a projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public float speed = 2000f;   // this is the projectile's speed
    public float lifespan = 3f; // this is the projectile's lifespan (in seconds)

    private Rigidbody m_rigidbody;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Message that is called before the first frame update
    /// </summary>
    void Start()
    {
        m_rigidbody.AddForce(transform.forward * speed);
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}