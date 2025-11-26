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
        transform.Translate(newPos, 0f, 0f);

        if (transform.localPosition.x <= -12.5f)
        {
            gameObject.SetActive(false);
        }
    }
    public void incrementSpeed(int inc)
    {
        hurdleSpeed += inc;
    }
}
