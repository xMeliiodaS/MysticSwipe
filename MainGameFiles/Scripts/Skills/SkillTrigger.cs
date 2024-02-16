using UnityEngine;

public class SkillTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DamagePopup.GetInstance().CreatePopup(other.transform.position + new Vector3(0, .7f, 0), "50", Color.white);
            Destroy(other.gameObject);
        }
    }
}
