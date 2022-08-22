using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    #region Singleton
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }
    private void SetSingleton()
    {
        if (instance != null && instance != this) Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion


    private float _horizontalInput;
    private bool _jumpHold;

    public float GetHorizontalInput() => _horizontalInput;
    public bool GetJumpHold() => _jumpHold;

    public delegate void JumpTriggered();
    public event JumpTriggered OnJumpTriggered;

    public delegate void DashTriggered();
    public event DashTriggered OnDashTriggered;

    private void Awake()
    {
        SetSingleton();
    }

    public void OnMove(InputAction.CallbackContext ctx) => _horizontalInput = ctx.ReadValue<float>();

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started) OnJumpTriggered?.Invoke();
        if (ctx.performed) _jumpHold = true;
        else _jumpHold = false;
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.started) OnDashTriggered?.Invoke();
    }



}
