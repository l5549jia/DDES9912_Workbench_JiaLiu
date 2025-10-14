using UnityEngine;

public class SpinY_Ball: MonoBehaviour
{
    public float ySpeed;
    public bool isActive = true; 

    public float slowY = 120f;
    public float normalY = 360f;
    public float fastY = 720f;
    public int speedMode = 1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ySpeed = normalY;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        transform.Rotate(0, ySpeed * Time.deltaTime, 0);
    }

    public void ToggleActive()
    {
        isActive = !isActive;
    }

    public void SwitchSpeed()
    {
        speedMode = (speedMode + 1) % 3;
        if (speedMode == 0) ySpeed = slowY;
        else if (speedMode == 1) ySpeed = normalY;
        else ySpeed = fastY;
    }
}
