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
        if (instance != this && instance != null) Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    public float _directionInp;
    public bool _jumpPressed;

    public delegate void JumpTrigged();
    public event JumpTrigged OnJumpTriggered;

    private void Awake()
    {
        SetSingleton();
    }


    public void OnPlayerMove(InputAction.CallbackContext ctx) => _directionInp = ctx.ReadValue<float>();
    public void OnPlayerJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started) OnJumpTriggered?.Invoke();
        if (ctx.performed) _jumpPressed = true;
        else _jumpPressed = false;
    }




}
