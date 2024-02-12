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
        transform.position += new Vector3(0, 0, roadMove.RoadSpeed - objectSpeed) * Time.deltaTime;
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float ObjectSpeed
    {
        get { return objectSpeed; }
        set { objectSpeed = value; }
    }
}
