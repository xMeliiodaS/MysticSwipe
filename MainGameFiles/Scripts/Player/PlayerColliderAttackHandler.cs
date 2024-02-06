using UnityEngine;

public class PlayerColliderAttackHandler : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Attack");
        }
    }
}
