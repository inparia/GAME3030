using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterShoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform m_SpawnTransform;
    private Animator animator;
    public AudioSource reloadSound, gunShot;
    public int bulletCount;
    public bool ableToShoot;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        bulletCount = 20;
        ableToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gamePaused)
        {
            if (Input.GetKeyDown("r"))
            {
                StartCoroutine(reload(1f));
            }

            if (Input.GetMouseButtonDown(0) && bulletCount > 0 && ableToShoot)
            {
                StartCoroutine(shoot(0.3f));
                var bullet = Instantiate(projectile, m_SpawnTransform.position, transform.rotation);
            }
        }
    }

    private IEnumerator shoot(float animationLength)
    {
        animator.SetBool("isShoot", true);
        bulletCount--;
        gunShot.Play();
        yield return new WaitForSeconds(animationLength);
        animator.SetBool("isShoot", false);
    }

    private IEnumerator reload(float animationLength)
    {
        ableToShoot = false;
        reloadSound.Play();
        yield return new WaitForSeconds(animationLength);
        bulletCount = 20;
        ableToShoot = true;
    }
}
