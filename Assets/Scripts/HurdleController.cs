using UnityEngine;

public class HurdleController : MonoBehaviour
{
    public int hurdleSpeed = 3;

    void Start()
    {
        
    }

    void Update()
    {
        float newPos = -1f * hurdleSpeed * Time.deltaTime;
        //transform.localPosition -= new Vector3(newPos, 0f, 0f);
        transform.Translate(newPos, 0f, 0f);

        if (transform.localPosition.x <= -12f)
        {
            Destroy(gameObject);
        }
    }
    public void incrementSpeed(int inc)
    {
        hurdleSpeed += inc;
    }
}
