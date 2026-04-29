using UnityEngine;
using System.Collections;
public class Flicker : MonoBehaviour
{
    private Light _light;
    public float minIntensity = 5;
    public float maxIntensity = 10f;
    public float duration = 2f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _light = GetComponent<Light>();
        StartCoroutine(FadeLight());
    }
    IEnumerator FadeLight()
    {
        while (true) // Repeat forever
        {
            // --- Increase Intensity ---
            yield return StartCoroutine(FadeIntensity(minIntensity, maxIntensity, duration));

            // --- Decrease Intensity ---
            yield return StartCoroutine(FadeIntensity(maxIntensity, minIntensity, duration));
        }
    }
    IEnumerator FadeIntensity(float startIntensity, float endIntensity, float time)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            _light.intensity = Mathf.Lerp(startIntensity, endIntensity, elapsed / time);
            yield return null; // Wait for next frame
        }
        _light.intensity = endIntensity; // Ensure final value is exact
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
