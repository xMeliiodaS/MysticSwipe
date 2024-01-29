using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float swipeSpeed = 3f;
    [SerializeField] private GameObject playerCamera;
    private Rigidbody rb;
    private Vector2 touchStartPos;
    private bool isSwiping = false;
    private int currentLane = 0; // 0 represents the middle lane

    // Define the lane positions
    private readonly Vector3[] lanePositions = { new(-2.5f, 0, 0), new(-1.25f, 0, 0), new(1.25f, 0, 0), new(2.5f, 0, 0) };

    private float cameraPy;
    private float cameraPz;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Player always start at lane number 1
        currentLane = 1;

        // Save the camera position
        cameraPy = playerCamera.transform.position.y;
        cameraPz = playerCamera.transform.position.z;
    }

    void Update()
    {
        Debug.Log(currentLane);
        // Check for user input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Detect the start of a swipe
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwiping = true;
            }

            // Detect the end of a swipe
            else if (touch.phase == TouchPhase.Ended)
            {
                isSwiping = false;

                // Stop the player immediately
                StopPlayer();
            }

            // Swipe movement
            if (isSwiping)
            {
                Vector2 swipeDelta = touch.position - touchStartPos;

                // Check if the swipe is horizontal (left or right)
                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    // Move the player based on the direction of the swipe
                    // NOTE:
                    // positive direction mean right.
                    // negative direction mean left.
                    float direction = Mathf.Sign(swipeDelta.x);
                    SwitchLane(direction);

                    isSwiping = false;
                }
            }
        }
    }

    void SwitchLane(float direction)
    {
        //Debug.Log("Before " + currentLane);
        if (currentLane == 0 && direction < 0 || currentLane == lanePositions.Length - 1 && direction > 0)
        {
            Debug.Log("Already at the leftmost/rightmost lane.");
            return; // Don't allow further left swiping
        }

        // Update the current lane based on the swipe direction

        // Swiped to the right
        if(direction < 0)
        {
            currentLane++;
        }
        else if (direction > 0)
        {
            currentLane--;
        }

        //currentLane = Mathf.Clamp(currentLane + (int)direction, 0, lanePositions.Length - 1);
        //Debug.Log("After " + currentLane);

        // Move the player to the new lane position with constant Z position
        Vector3 targetPosition = new (lanePositions[currentLane].x, 0, 0);
        Vector3 cameraTargetPosition = new(lanePositions[currentLane].x, cameraPy, cameraPz);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * swipeSpeed);

        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, cameraTargetPosition, Time.deltaTime * swipeSpeed);

        StopPlayer();
    }

    
    void StopPlayer()
    {
        // Stop the player immediately by setting velocity to zero
        rb.velocity = Vector3.zero;
    }


    void MovePlayer(float direction)
    {
        // Calculate the movement vector
        Vector3 moveVector = new Vector3(direction, 0, 0) * swipeSpeed * Time.deltaTime;

        // Move the player
        transform.Translate(moveVector);
    }

}
