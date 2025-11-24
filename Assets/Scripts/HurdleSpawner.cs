using System.Collections;
using UnityEngine;

public class HurdleSpawner : MonoBehaviour
{
    public int hurdleSpeed = 0;
    public GameObject hurdle;
    public GameObject curHurdle;
    public PlayerController player;
    public bool readyForNextHurdle = true;

    void Start()
    {
        //GameObject spawnedHurdle = Instantiate(hurdle);
        //hurdleSpeed++;
    }

    void Update()
    {
        if (readyForNextHurdle)
        {
            SpawnHurdle();
            hurdleSpeed++;
            readyForNextHurdle = false;
        }

        if (curHurdle.gameObject.transform.position.x <= -12)
        {
            KillHurdle();
        }
    }

    void SpawnHurdle()
    {
        curHurdle = Instantiate(hurdle, gameObject.transform.position, gameObject.transform.rotation);
        var hs = curHurdle.GetComponent<HurdleController>();
        hs.incrementSpeed(hurdleSpeed);
        player.nextHurdle = curHurdle;
    }

    void KillHurdle()
    {
        Destroy(curHurdle);
        Ready();
    }

    public void Ready()
    {
        readyForNextHurdle = true;
    }
}
