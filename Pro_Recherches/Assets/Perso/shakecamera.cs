using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakecamera : MonoBehaviour
{
    private static shakecamera _instance;
    public static shakecamera Instance { get { return _instance; } }

    public float shakeDuration = 0.2f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPos;
    private float currentShakeDuration = 0f;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            currentShakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }

    public void Shake(float duration)
    {
        currentShakeDuration = duration;
    }
}
