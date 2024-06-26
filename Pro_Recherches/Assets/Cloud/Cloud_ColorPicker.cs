using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_ColorPicker : MonoBehaviour
{
    public Gradient colorGradient;

    private ParticleSystem particleSystem1;
    private ParticleSystem particleSystem2;

    void Start()
    {
        // Get the two particle systems that are children of this GameObject
        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        if (particleSystems.Length < 2)
        {
            Debug.LogError("There should be at least 2 Particle Systems as children of this GameObject.");
            return;
        }

        particleSystem1 = particleSystems[0];
        particleSystem2 = particleSystems[1];

        // Apply the gradient to the custom data of the first particle system
        ApplyGradientToCustomData(particleSystem1);

        // Apply the gradient to the color over lifetime of the second particle system
        ApplyGradientToColorOverLifetime(particleSystem2);
    }

    void ApplyGradientToCustomData(ParticleSystem ps)
    {
        var customData = ps.customData;
        customData.enabled = true;

        // Enable custom color data
        customData.SetMode(ParticleSystemCustomData.Custom1, ParticleSystemCustomDataMode.Vector);

        // Set the gradient
        ParticleSystem.MinMaxGradient minMaxGradient = new ParticleSystem.MinMaxGradient(colorGradient);
        customData.SetVectorComponentCount(ParticleSystemCustomData.Custom1, 3); // For RGB
        //customData.SetVector(ParticleSystemCustomData.Custom1, minMaxGradient);
    }

    void ApplyGradientToColorOverLifetime(ParticleSystem ps)
    {
        var colorOverLifetime = ps.colorOverLifetime;
        colorOverLifetime.enabled = true;
        colorOverLifetime.color = new ParticleSystem.MinMaxGradient(colorGradient);
    }
}
