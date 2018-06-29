using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    enum playerState
    {
        GoingUp,
        GoingDown,
        GoingRight,
        GoingLeft,
        IDLE
    }

    playerState state;
    public bool canMove;

    Rigidbody2D rbd2;
    Animator anim;

    public float speed = 3;


    int lifes = 3;
    public bool isInvincible = false;
    public GameObject stock1;
    public GameObject stock2;
    public GameObject stock3;
    public Color[] colors;
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        state = playerState.IDLE;
        canMove = true;
    }

    void Update()
    {

        float posX = Input.GetAxisRaw("Horizontal");
        float posY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(posX, posY, 0) * Time.deltaTime;

        if (canMove)
        {
            // switch con todos los estados
            switch (state)
            {
                // cada estado tiene
                // - acción a ejecutar
                // - condicioes de salida

                case playerState.GoingUp:
                    {
                        // acción:
                        if (Input.GetKey(KeyCode.W))
                        {
                            rbd2.velocity = new Vector2(0, speed);
                            anim.SetBool("isIdle", false);
                            anim.SetBool("isAttacking", false);
                            anim.SetBool("isWalkingDown", false);
                            anim.SetBool("isWalkingRight", false);
                            anim.SetBool("isWalkingLeft", false);
                            anim.SetBool("isWalkingUp", true);

                            if (Input.GetKeyDown(KeyCode.J))
                            {
                                anim.SetBool("isWalkingUp", false);
                                anim.SetBool("isAttacking", true);
                            }
                        }

                        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
                        {
                            state = playerState.GoingDown;
                        }
                        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
                        {
                            state = playerState.GoingRight;
                        }
                        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W))
                        {
                            state = playerState.GoingLeft;
                        }
                        if (!Input.anyKey)
                        {
                            state = playerState.IDLE;
                        }

                        break;
                    }

                case playerState.GoingDown:
                    {
                        if (Input.GetKey(KeyCode.S))
                        {
                            rbd2.velocity = new Vector2(0, -speed);
                            anim.SetBool("isIdle", false);
                            anim.SetBool("isAttacking", false);
                            anim.SetBool("isWalkingUp", false);
                            anim.SetBool("isWalkingRight", false);
                            anim.SetBool("isWalkingLeft", false);
                            anim.SetBool("isWalkingDown", true);

                            if (Input.GetKeyDown(KeyCode.J))
                            {
                                anim.SetBool("isWalkingDown", false);
                                anim.SetBool("isAttacking", true);
                            }
                        }

                        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
                        {
                            state = playerState.GoingUp;
                        }
                        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
                        {
                            state = playerState.GoingRight;
                        }
                        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
                        {
                            state = playerState.GoingLeft;
                        }
                        if (!Input.anyKey)
                        {
                            state = playerState.IDLE;
                        }

                        break;
                    }

                case playerState.GoingRight:
                    {
                        if (Input.GetKey(KeyCode.D))
                        {
                            rbd2.velocity = new Vector2(speed, 0);
                            anim.SetBool("isIdle", false);
                            anim.SetBool("isAttacking", false);
                            anim.SetBool("isWalkingUp", false);
                            anim.SetBool("isWalkingDown", false);
                            anim.SetBool("isWalkingLeft", false);
                            anim.SetBool("isWalkingRight", true);

                            if (Input.GetKeyDown(KeyCode.J))
                            {
                                anim.SetBool("isWalkingRight", false);
                                anim.SetBool("isAttacking", true);
                            }
                        }

                        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
                        {
                            state = playerState.GoingUp;
                        }
                        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
                        {
                            state = playerState.GoingDown;
                        }
                        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                        {
                            state = playerState.GoingLeft;
                        }
                        if (!Input.anyKey)
                        {
                            state = playerState.IDLE;
                        }

                        break;
                    }

                case playerState.GoingLeft:
                    {
                        if (Input.GetKey(KeyCode.A))
                        {
                            rbd2.velocity = new Vector2(-speed, 0);
                            anim.SetBool("isIdle", false);
                            anim.SetBool("isAttacking", false);
                            anim.SetBool("isWalkingUp", false);
                            anim.SetBool("isWalkingRight", false);
                            anim.SetBool("isWalkingDown", false);
                            anim.SetBool("isWalkingLeft", true);

                            if (Input.GetKeyDown(KeyCode.J))
                            {
                                anim.SetBool("isWalkingLeft", false);
                                anim.SetBool("isAttacking", true);
                            }
                        }

                        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A))
                        {
                            state = playerState.GoingUp;
                        }
                        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A))
                        {
                            state = playerState.GoingDown;
                        }
                        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
                        {
                            state = playerState.GoingRight;
                        }
                        if (!Input.anyKey)
                        {
                            state = playerState.IDLE;
                        }

                        break;
                    }

                case playerState.IDLE:
                    {
                        if (!Input.anyKey)
                        {
                            anim.SetBool("isWalkingUp", false);
                            anim.SetBool("isWalkingDown", false);
                            anim.SetBool("isWalkingLeft", false);
                            anim.SetBool("isWalkingRight", false);
                            anim.SetBool("isIdle", true);
                        }

                        if (Input.GetKey(KeyCode.W))
                        {
                            state = playerState.GoingUp;
                        }
                        if (Input.GetKey(KeyCode.S))
                        {
                            state = playerState.GoingDown;
                        }
                        if (Input.GetKey(KeyCode.D))
                        {
                            state = playerState.GoingRight;
                        }
                        if (Input.GetKey(KeyCode.A))
                        {
                            state = playerState.GoingLeft;
                        }

                        break;
                    }
            }
        }


        if(lifes == 3)
        {
            stock1.SetActive(true);
            stock2.SetActive(true);
            stock3.SetActive(true);
        }

        if (lifes == 2)
        {
            stock1.SetActive(true);
            stock2.SetActive(true);
            stock3.SetActive(false);
        }

        if (lifes == 1)
        {
            stock1.SetActive(true);
            stock2.SetActive(false);
            stock3.SetActive(false);
        }

        if (lifes == 0)
        {
            stock1.SetActive(false);
            stock2.SetActive(false);
            stock3.SetActive(false);

            StartCoroutine(DeathAnimation());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy" && !isInvincible)
        {
            StartCoroutine(Invincible());

        }
    }

    IEnumerator Invincible()
    {
        lifes -= 1;
        isInvincible = true;
        GetComponent<Collider2D>().enabled = false;

        GetComponent<SpriteRenderer>().material.color = colors[0];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[1];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[0];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[1];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[0];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[1];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[0];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[1];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[0];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[1];
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().material.color = colors[0];

        GetComponent<Collider2D>().enabled = true;
        isInvincible = false;

    }

    IEnumerator DeathAnimation()
    {
        anim.SetBool("isWalkingUp", false);
        anim.SetBool("isWalkingDown", false);
        anim.SetBool("isWalkingLeft", false);
        anim.SetBool("isWalkingRight", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isIdle", true);
        canMove = false;
        transform.Rotate(0, 0, -10);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(0);
    }
}
