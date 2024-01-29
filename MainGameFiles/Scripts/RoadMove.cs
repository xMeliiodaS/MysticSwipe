using UnityEngine;

public class RoadMove : MonoBehaviour
{

    [SerializeField] private float roadSpeed;
    private void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, roadSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyRoad"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DestroyRoad"))
        {
            Destroy(gameObject);
        }
    }
}
