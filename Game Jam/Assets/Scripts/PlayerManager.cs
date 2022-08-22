using UnityEngine;

[RequireComponent(typeof(Ground))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    public PlayerTypeSO settings;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public Motor motor_Script;
    [HideInInspector] public Jump jump_Script;
    [HideInInspector] public Dash dash_Script;
    [HideInInspector] public Ground ground;
    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        ground = GetComponent<Ground>();
        inputManager = InputManager.Instance;
        rb = GetComponent<Rigidbody2D>();

        if (settings.playerType == PlayerTypeSO.PlayerType.Player)
        {
            TryGetPlayerFiles();
            if (motor_Script != null) motor_Script.enabled = true;
            if (jump_Script != null) jump_Script.enabled = true;
            if (dash_Script != null) dash_Script.enabled = true;
        }

    }


    private void TryGetPlayerFiles()
    {
        if (TryGetComponent<Motor>(out Motor motor)) motor_Script = GetComponent<Motor>();
        if (TryGetComponent<Jump>(out Jump jump)) jump_Script = GetComponent<Jump>();
        if (TryGetComponent<Dash>(out Dash dash)) dash_Script = GetComponent<Dash>();
    }

}
