using UnityEngine;

public class ColorBlink : MonoBehaviour
{
    public Renderer targetRenderer; 

    public Color colorA = Color.red; 
    public Color colorB = Color.blue; 
    public float interval = 1f;       

    private Material mat;         
    private float timer = 0f;
    private bool useA = true;

    void Start()
    {
        mat = targetRenderer.material;

        mat.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            useA = !useA;

            Color c = useA ? colorA : colorB;

            mat.color = c;

            mat.SetColor("_EmissionColor", c);
        }
    }
}