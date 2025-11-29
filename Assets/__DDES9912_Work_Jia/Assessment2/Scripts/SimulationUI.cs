using UnityEngine;
using TMPro;

public class SimulationUI : MonoBehaviour
{
    public SimulationManager sim;
    public TextMeshProUGUI pressureText;
    public TextMeshProUGUI speedText;

    void Update()
    {
        if (sim == null) return;

        float pressurePercent = sim.pressure * 100f;

        pressureText.text = "Pressure: " + pressurePercent.ToString("0");
        speedText.text = "Speed: " + sim.engineSpeed.ToString("0");
    }
}
