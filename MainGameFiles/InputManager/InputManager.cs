using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;

    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    #endregion
    #region Singelton
    public static InputManager Instance { get; private set; } 

    #endregion
    private TouchControl touchControl;
    private Camera mainCamera;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;

        touchControl = new TouchControl();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchControl.Enable();
    }

    private void OnDisable()
    {
        touchControl.Disable();
    }

    void Start()
    {
        touchControl.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        touchControl.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(Utils.ScreenToWorld(mainCamera, touchControl.Touch.PrimaryPosition.ReadValue<Vector2>()),
            (float)context.startTime);
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(Utils.ScreenToWorld(mainCamera, touchControl.Touch.PrimaryPosition.ReadValue<Vector2>()),
            (float)context.time);
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCamera, touchControl.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

}
