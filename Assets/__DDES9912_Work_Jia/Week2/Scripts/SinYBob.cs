using UnityEngine;

public class SinYBob : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 sinOffset;
    public float alpha;
    public float sinValue;
    public float rangeFactor = 0.5f;
    public float bobSpeed = 90f;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void Update()
    {
        sinValue = Mathf.Sin(alpha * Mathf.Deg2Rad);
        sinOffset.x = 0f;
        sinOffset.y = sinValue * rangeFactor;
        sinOffset.z = 0f;

        transform.localPosition = startPosition + sinOffset;
        alpha += bobSpeed * Time.deltaTime;
    }
}
