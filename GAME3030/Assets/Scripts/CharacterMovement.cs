using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public GameObject pausePanel, mainPanel;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        isDead = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.gamePaused)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            if (!isDead)
            {
                Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                controller.Move(move * Time.deltaTime * playerSpeed);

                if (move != Vector3.zero)
                {
                    gameObject.transform.forward = move;
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetBool("isRunning", false);
                }
                // Changes the height position of the player..
                if (Input.GetButtonDown("Jump") && groundedPlayer)
                {
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                }
            }
                playerVelocity.y += gravityValue * Time.deltaTime;
                controller.Move(playerVelocity * Time.deltaTime);
            if (!isDead)
            {
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

                //Get the Screen position of the mouse
                Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

                //Get the angle between the points
                float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

                transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 90, 0f));
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.Instance.gamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

        if (GameManager.Instance.playerHp <= 0)
        {
            isDead = true;
            animator.SetBool("isDead", isDead);
            GameManager.Instance.delayScene(5, "Lose");
            GameManager.Instance.gameReset();
        }

    }

    public void ResumeGame()
    {
        GameManager.Instance.gamePaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    private void PauseGame()
    {
        GameManager.Instance.gamePaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
