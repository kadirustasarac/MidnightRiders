using System.Collections;
using UnityEngine;

public class PoliceLightController : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;
    public float flashDuration = 0.5f; // Her ışığın açık kalma süresi

    private void Start()
    {
        // Coroutine başlat
        StartCoroutine(FlashLights());
    }

    private IEnumerator FlashLights()
    {
        while (true)
        {
            // Kırmızı ışık yanar, mavi ışık söner
            redLight.enabled = true;
            blueLight.enabled = false;
            yield return new WaitForSeconds(flashDuration);

            // Mavi ışık yanar, kırmızı ışık söner
            redLight.enabled = false;
            blueLight.enabled = true;
            yield return new WaitForSeconds(flashDuration);
        }
    }
}