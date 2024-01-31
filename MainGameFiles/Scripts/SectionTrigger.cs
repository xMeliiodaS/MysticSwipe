using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    [SerializeField] private GameObject road;
    [SerializeField] private int numberOfRoadToClone;
    private int currentRoad = 0;

    private void Start()
    {
        //InvokeRepeating(nameof(InstantiateRoad), 1f, 5f);
    }

    private void InstantiateRoad()
    {
        if (currentRoad < numberOfRoadToClone)
        {
            Instantiate(road, new Vector3(0, 0, 93.95f), Quaternion.Euler(0, 0, 0));
            currentRoad++;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("SpawnRoad"))
    //    {
    //        if (currentRoad < numberOfRoadToClone)
    //        {
    //            Instantiate(road, new Vector3(0, 0, 93.95f), Quaternion.Euler(0, 0, 0));
    //            currentRoad++;
    //        }
    //    }
    //}
}
