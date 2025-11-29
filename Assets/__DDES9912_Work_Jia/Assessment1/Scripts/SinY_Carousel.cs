using UnityEngine;

public class SinY_Carousel : MonoBehaviour
{
    public Vector3 startPosition; // Original local position of the piston
    public Vector3 sinOffset;     // Temporary offset during movement
    public float angle;           // Current angle for sine calculation
    public float sinValue;        // Current sine value

    public float rangeFactor = 0.4f; // Movement amplitude
    public float bobSpeed =100f;    // Oscillation speed
    public bool isActive = true;     // Whether the piston is moving

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.localPosition; // Record initial position
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return; // Stop moving when inactive

        sinValue = Mathf.Sin(angle * Mathf.Deg2Rad);

        sinOffset.x = 0f;
        sinOffset.y = sinValue * rangeFactor;
        sinOffset.z = 0f;

        transform.localPosition = startPosition + sinOffset;

        angle += bobSpeed * Time.deltaTime; // Continuous rotation angle
    }

    // Increase piston speed (for UI button)
    public void Faster()
    {
        bobSpeed *= 150f;
    }

    // Decrease piston speed (for UI button)
    public void Slower()
    {
        bobSpeed *= 50f;
    }

    // Toggle movement on/off (used for Start/Stop button)
    public void ToggleActive()
    {
        isActive = !isActive;
    }
}
