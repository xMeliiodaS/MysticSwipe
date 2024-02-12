using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    [SerializeField] private float minDistance = 0.2f;
    [SerializeField] private float maxTime = 1f;
    [SerializeField, Range(0, 1f)] private float directionThreshold = 0.9f;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerCamera;

    [SerializeField] private float swipeCooldownDuration = 0.3f;
    private bool isSwipeInCooldown = false;

    private InputManager inputManager;

    [Tooltip("Lanes")]
    private int currentLane;
    private readonly int minLane = 0;
    private readonly int maxLane = 3;

    private Vector2 startPos;
    private float startTime;

    private Vector2 endPos;
    private float endTime;


    private void Awake()
    {
        inputManager = InputManager.Instance;
        currentLane = 1;
    }

    // Subscribe to functions
    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    // Unsubscribe to functions
    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }


    /// <summary>
    /// When the swipe starts, save the position of it and the time.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="time"></param>
    private void SwipeStart(Vector2 position, float time)
    {
        startPos = position;
        startTime = time;
        //trail.SetActive(true);
        //trail.transform.position = position;
        //coroutine = StartCoroutine(Trail());
    }


    /// <summary>
    /// When the swipe ends, save the end position of it and the time.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="time"></param>
    private void SwipeEnd(Vector2 position, float time)
    {
        //trail.SetActive(false);
        //StopCoroutine(coroutine);

        endPos = position;
        endTime = time;

        DetectSwipe();
    }

    /*private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }*/


    /// <summary>
    /// Detect if it was a swipe, if its too short or too slow then its not a swipe.
    /// </summary>
    private void DetectSwipe()
    {
        if (Vector3.Distance(startPos, endPos) > minDistance &&
            (endTime - startTime) <= maxTime)
        {
            Debug.DrawLine(startPos, endPos, Color.red, 5f);

            Vector3 direction = endPos - startPos;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }


    /// <summary>
    /// Moves the player character in the specified direction based on a swipe input.
    /// </summary>
    /// <param name="direction">Swipe direction vector.</param>
    private void SwipeDirection(Vector2 direction)
    {
        if (!isSwipeInCooldown)
        {
            StartCoroutine(SwipeCooldown(swipeCooldownDuration));

            Vector3 playerPos = player.transform.position;
            Vector3 targetPosition = new(0, 0, 0);

            // If swiping right
            if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
            {
                if(currentLane < maxLane)
                {
                    targetPosition = playerPos + new Vector3(1f, 0, 0);
                    currentLane++;

                    // Ensure the final position is exactly the target position
                    player.transform.position = targetPosition;
                }
            }
            // If swiping left
            else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
            {
                if(currentLane > minLane)
                {
                    targetPosition = playerPos + new Vector3(-1f, 0, 0);
                    currentLane--;

                    // Ensure the final position is exactly the target position
                    player.transform.position = targetPosition;
                }
            }
            // If the swipe direction wasn't to the right nor the left, do't do anything.
            else
            {
                return;
            }

            // TODO: Implement swipe effects, sound effects, and more.

            // Swipe Effect..


            // Sound Effect..


        }
    }

    private IEnumerator SwipeCooldown(float cooldownDuration)
    {
        isSwipeInCooldown = true;

        // Perform any visual effects or animations here

        yield return new WaitForSeconds(cooldownDuration);

        // Reset the cooldown flag
        isSwipeInCooldown = false;
    }
}
