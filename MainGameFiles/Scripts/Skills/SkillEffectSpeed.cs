using UnityEngine;

public class SkillEffectSpeed : MonoBehaviour
{
    private ParticleSystem particle;        // Reference to the ParticleSystem component
    private float originalSpeed;            // Original simulation speed of the ParticleSystem
    private float speedMultiplier = 1.55f;  // Multiplier to adjust the simulation speed


    void Start()
    {
        AdjustSimulationSpeed();
    }


    /// <summary>
    /// Adjusts the simulation speed of the ParticleSystem component.
    /// </summary>
    private void AdjustSimulationSpeed()
    {
        if (TryGetComponent(out particle))
        {
            var mainModule = particle.main; // Accessing main module
            originalSpeed = mainModule.simulationSpeed;
            mainModule.simulationSpeed = originalSpeed * speedMultiplier;
        }
    }
}
