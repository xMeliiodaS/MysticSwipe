using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    [SerializeField] private RoadMove roadMove;
    [SerializeField] private float enemySpeed;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = roadMove.RoadSpeed - enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}
