using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce = 5;
    public Rigidbody2D rb;
    public HurdleSpawner spawner;
    public GameObject nextHurdle;

    private bool promptingJump = false;
    private KeyCode jumpKey;
    private List<KeyCode> level1Library = new List<KeyCode>();
    private List<KeyCode> level2Library = new List<KeyCode>();
    private List<KeyCode> level3Library = new List<KeyCode>();
    private float distanceToNextHurdle;
    

    void Start()
    {
        if(rb != null)
            rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        if(nextHurdle.transform.position.x <= 7)
        {
            promptingJump = true;
        }

        if (promptingJump)
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.localPosition.y < -.75f)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                //spawner.Ready();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hurdle"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
    }
}
