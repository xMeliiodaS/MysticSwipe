using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    [SerializeField] private RoadMove roadMove;
    [SerializeField] private float objectSpeed;
    private float speed;


    void Start()
    {
        speed = roadMove.RoadSpeed - objectSpeed;
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}
