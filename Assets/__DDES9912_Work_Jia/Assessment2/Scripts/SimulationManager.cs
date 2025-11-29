using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    [Header("Engine reference")]
    public SpinX_Wheels driveWheel; 

    [Header("Simulation Values (read-only from engine)")]
    [Range(0f, 1f)]
    public float pressure;   
    public float engineSpeed; 

    [Header("Speed Range Mapping")]
    public float minSpeed = 120f; 
    public float maxSpeed = 720f;

    void Update()
    {
        if (driveWheel == null) return;

        engineSpeed = Mathf.Abs(driveWheel.xSpeed);

        pressure = Mathf.InverseLerp(minSpeed, maxSpeed, engineSpeed);
    }
}
