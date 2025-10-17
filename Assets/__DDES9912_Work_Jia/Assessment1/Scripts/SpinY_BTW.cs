using UnityEngine;

public class SpinY_BTW : MonoBehaviour
{
    public float ySpeed;
    public bool isActive = true;

    public float slowY = 30f;     // Slow rotation speed (deg/sec)
    public float normalY = 60f;  // Normal rotation speed
    public float fastY = 90f;    // Fast rotation speed
    public int speedMode = 1;     // 0 = slow, 1 = normal, 2 = fast

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ySpeed = normalY; // Default speed at start
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return; // Stop rotation when inactive
        transform.Rotate(0, ySpeed * Time.deltaTime, 0); // Rotate around Y-axis
    }

    // Toggle rotation on/off (for Start/Stop button)
    public void ToggleActive()
    {
        isActive = !isActive;
    }

    // Switch between slow / normal / fast speed modes (for Speed button)
    public void SwitchSpeed()
    {
        speedMode = (speedMode + 1) % 3;
        if (speedMode == 0) ySpeed = slowY;
        else if (speedMode == 1) ySpeed = normalY;
        else ySpeed = fastY;
    }
}