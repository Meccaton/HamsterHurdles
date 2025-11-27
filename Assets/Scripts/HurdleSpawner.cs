using System.Collections;
using UnityEngine;

public class HurdleSpawner : MonoBehaviour
{
    public int hurdleSpeed = 0;
    public GameObject hurdle;
    public PlayerController player;
    public float recoveryTime = .5f;
    public float approachTime = 1.0f;

    private float lastJump;
    private bool ready = true;

    void Start()
    {
        lastJump = -999;
    }

    void Update()
    {
        float timeSinceJump = Time.time - lastJump;
        float requiredTime = recoveryTime + approachTime;

        if (ready)// && timeSinceJump >= requiredTime)
        {
            SpawnHurdle();
            hurdleSpeed++;
            ready = false;
        }
    }

    private void SpawnHurdle()
    {
        GameObject spawnedHurdle = Instantiate(hurdle, transform.position, transform.rotation);
        var hs = spawnedHurdle.GetComponent<HurdleController>();
        hs.incrementSpeed(hurdleSpeed);
        player.nextHurdle = spawnedHurdle;
    }

    public void OnJump()
    {
        lastJump = Time.time;
        ready = true;
    }

    public void Ready()
    {
        ready = true;
    }
}
