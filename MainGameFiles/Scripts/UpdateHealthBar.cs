using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void UpdateHealth(float percentage)
    {
        healthSlider.value = percentage;
    }

    public void UpdateMaxHealth(float percentage)
    {
        healthSlider.maxValue = percentage;
    }
}
