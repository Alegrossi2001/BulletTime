using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        float timeShaking = 0.1f;
        while(timeShaking < duration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, originalPos.z);
            timeShaking += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPos;
    }
}
