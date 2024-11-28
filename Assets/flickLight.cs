using System.Collections;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public float minWaitTime = 0.1f;
    public float maxWaitTime = 0.5f;

    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (true)
        {
            lightComponent.enabled = !lightComponent.enabled;
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}

