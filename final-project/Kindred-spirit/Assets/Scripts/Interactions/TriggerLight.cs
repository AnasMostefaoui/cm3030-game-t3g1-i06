using System.Collections;
using UnityEngine;

public class TriggerLight : MonoBehaviour
{
    public float lightIncreaseRate = 0.25f;
    public float lightIncreasePerTime = 0.1f;
    public float lightIntensityTarget = 15f;
    private Light triggerLight;

    public void StartFade()
    {
        triggerLight = gameObject.GetComponent<Light>();
        StartCoroutine(FadeLight());
    }

    IEnumerator FadeLight()
    {
        // Wait for the required time
        yield return new WaitForSeconds(lightIncreasePerTime);
        // Increase the Light
        triggerLight.intensity = Mathf.Clamp((triggerLight.intensity + lightIncreaseRate), 0, lightIntensityTarget);
        
        // Check if target reached
        if (triggerLight.intensity < lightIntensityTarget)
        {
            StartCoroutine(FadeLight());
        }
    }
}
