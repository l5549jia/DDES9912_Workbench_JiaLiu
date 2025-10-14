using UnityEngine;

public class SpinX_Wheels : MonoBehaviour
{
    public float xSpeed;
    public bool isActive = true;

    public float slowX = 120f;
    public float normalX = 360f;
    public float fastX = 720f;
    public int speedMode = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xSpeed = normalX;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        transform.Rotate(xSpeed * Time.deltaTime, 0, 0);
    }

    public void ToggleActive()
    {
        isActive = !isActive;
    }

    public void SwitchSpeed()
    {
        speedMode = (speedMode + 1) % 3;
        if (speedMode == 0) xSpeed = slowX;
        else if (speedMode == 1) xSpeed = normalX;
        else xSpeed = fastX;
    }
}
