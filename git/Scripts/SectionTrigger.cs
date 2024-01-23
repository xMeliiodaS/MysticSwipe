using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject road;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CloneRoad"))
        {
            Instantiate(road, new Vector3(0, 0, 15.923f), Quaternion.Euler(0, 0, 0));
        }
    }
}
