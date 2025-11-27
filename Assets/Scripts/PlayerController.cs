using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float defGrav = 1f;
    public float fastGrav = 2f;
    public Rigidbody2D rb;
    public HurdleSpawner spawner;
    public GameObject nextHurdle = null;
    public KeyCodeLibrary kcl;
    public TextManager tm;
    public GameObject deadPlayer;
    public ScoreManager sm;

    private int numJumps = 0;
    private bool ez = true;
    private KeyCode jumpKey1 = KeyCode.Space;
    private KeyCode jumpKey2;

    void Start()
    {
        if(rb != null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(ez)
        {
            if (Input.GetKeyDown(jumpKey1))
            {
                if (transform.localPosition.y < -.75f)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                    numJumps++;

                    if (numJumps < 6)
                    {
                        jumpKey1 = kcl.getEz();
                        tm.UpdateJumpKey(jumpKey1);
                    }
                    else if (numJumps < 11)
                    {
                        jumpKey1 = kcl.getMid();
                        tm.UpdateJumpKey(jumpKey1);
                    }
                    else
                    {
                        jumpKey1 = kcl.getMid();
                        jumpKey2 = kcl.getHard();
                        tm.UpdateTwoJumpKeys(jumpKey1, jumpKey2);
                        tm.EnableSecondKey();
                        ez = false;
                    }
                }
            }
        }
        else
        {
            if (Input.GetKey(jumpKey1) && Input.GetKey(jumpKey2))
            {
                if(transform.localPosition.y < -.75f)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                    numJumps++;

                    jumpKey1 = kcl.getMid();
                    jumpKey2 = kcl.getHard();
                    tm.UpdateTwoJumpKeys(jumpKey1, jumpKey2);
                }
            }
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = fastGrav;
        }
        else
        {
            rb.gravityScale = defGrav;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hurdle"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnTrigger"))
        {
            sm.UpdateCurScore();
            spawner.OnJump();
        }
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
        deadPlayer.transform.position = gameObject.transform.position;
        deadPlayer.SetActive(true);
        sm.SetHighScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
