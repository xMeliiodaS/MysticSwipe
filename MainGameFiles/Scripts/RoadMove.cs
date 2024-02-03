using UnityEngine;

public class RoadMove : MonoBehaviour
{

    [SerializeField] private float roadSpeed;
    [SerializeField] private float destroyAfterSeconds;
    private void Start()
    {
        //Application.targetFrameRate = 30;
        Destroy(gameObject, destroyAfterSeconds);
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
        if (other.CompareTag("SpawnRoad"))
        {
            Instantiate(gameObject, new Vector3(0, 0, 57.0876f), Quaternion.Euler(0, 0, 0));
        }
    }

    public float RoadSpeed
    {
        get { return roadSpeed; }
        set { roadSpeed = value; }
    }
}
