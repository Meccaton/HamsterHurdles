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

    private int numJumps = 0;
    private KeyCode jumpKey = KeyCode.Space;

    void Start()
    {
        if(rb != null)
            rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.GetKey(jumpKey))
        {
            if(transform.localPosition.y < -.75f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

                numJumps++;

                if(numJumps < 6)
                {
                    jumpKey = kcl.getEz();
                    tm.UpdateJumpKey(jumpKey);
                }
                else if(numJumps < 11)
                {
                    jumpKey = kcl.getMid();
                    tm.UpdateJumpKey(jumpKey);
                }
                else
                {
                    jumpKey = kcl.getHard();
                    tm.UpdateJumpKey(jumpKey);
                }
            }
        }

        if(rb.linearVelocity.y < 0)
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
            spawner.OnJump();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
