using UnityEngine;

public class RoadMove : MonoBehaviour
{

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -5f) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("eqwf");
        if (other.CompareTag("DestroyRoad"))
        {
            Debug.Log("eqwf");
            Destroy(gameObject);
            Debug.Log("eqwf");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("eqwf");
        if (other.CompareTag("DestroyRoad"))
        {
            Debug.Log("eqwf");
            Destroy(gameObject);
            Debug.Log("eqwf");
        }
    }
}
