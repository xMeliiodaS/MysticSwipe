using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject road;
    [SerializeField] private int numberOfRoadToClone;
    private int currentRoad = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CloneRoad"))
        {
            if (currentRoad < numberOfRoadToClone)
            {
                Instantiate(road, new Vector3(0, 0, 15.923f), Quaternion.Euler(0, 0, 0));
                currentRoad++;
            }
            else
            {
                // The final road contains the boss and his mules.
            }
        }
    }
}
