using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playfxandshake : MonoBehaviour
{
    public GameObject vfxObject; // Reference to the GameObject containing the VFX
    public float screenshakeDelay = 1.0f; // Delay before screenshake starts
    public float screenshakeDuration = 0.5f; // Duration of screenshake

    private bool hasPlayed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasPlayed)
        {
            // Play VFX
            if (vfxObject != null)
            {
                var vfx = vfxObject.GetComponent<ParticleSystem>();
                if (vfx != null)
                {
                    vfx.Play();
                }
            }

            // Start screenshake after delay
            Invoke("StartScreenshake", screenshakeDelay);

            hasPlayed = true; // Prevent multiple plays in one press
        }
    }

    void StartScreenshake()
    {
        shakecamera.Instance.Shake(screenshakeDuration);
    }
}