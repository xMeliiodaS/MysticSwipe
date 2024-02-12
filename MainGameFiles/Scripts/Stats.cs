using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }
}
