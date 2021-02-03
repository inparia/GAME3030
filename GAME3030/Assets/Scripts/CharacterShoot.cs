using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform m_SpawnTransform;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(projectile, m_SpawnTransform.position, transform.rotation);
        }
    }
}
