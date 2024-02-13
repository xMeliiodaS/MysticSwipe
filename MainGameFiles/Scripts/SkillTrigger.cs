using UnityEngine;

public class SkillTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
