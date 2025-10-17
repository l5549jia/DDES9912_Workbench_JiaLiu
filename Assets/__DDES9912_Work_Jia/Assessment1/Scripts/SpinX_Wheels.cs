using UnityEngine;

public class SpinX_Wheels : MonoBehaviour
{
    public float xSpeed;          // Current rotation speed around Z-axis
    public bool isActive = true;  // Whether rotation is active

    public float slowX = 120f;    // Slow rotation speed (deg/sec)
    public float normalX = 360f;  // Normal rotation speed
    public float fastX = 720f;    // Fast rotation speed
    public int speedMode = 1;     // 0 = slow, 1 = normal, 2 = fast

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xSpeed = normalX; // Default speed at start
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return; // Stop rotation when inactive
        transform.Rotate(xSpeed * Time.deltaTime, 0, 0); // Rotate around Z-axis
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
        if (speedMode == 0) xSpeed = slowX;
        else if (speedMode == 1) xSpeed = normalX;
        else xSpeed = fastX;
    }
}
