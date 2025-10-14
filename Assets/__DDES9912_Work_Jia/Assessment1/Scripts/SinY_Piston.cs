using UnityEngine;

public class SinY_Piston : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 sinOffset;
    public float angle;
    public float sinValue;

    public float rangeFactor = 4.5f;
    public float bobSpeed = 250f;
    public bool isActive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        sinValue = Mathf.Sin(angle * Mathf.Deg2Rad);

        sinOffset.x = 0f;
        sinOffset.y = sinValue * rangeFactor;
        sinOffset.z = 0f;

        transform.localPosition = startPosition + sinOffset;

        angle += bobSpeed * Time.deltaTime;
    }
    public void Faster()
    {
        bobSpeed *= 400f;
    }
    public void Slower()
    {
        bobSpeed *= 100f;
    }
    public void ToggleActive()
    {
        isActive = !isActive;
    }
}
