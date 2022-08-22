using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerTypeSO settings;
    public InputManager inputManager;
    public Motor motor_Script;
    public Jump jump_Script;
    public Dash dash_Script;

    private void Awake()
    {
        if(settings.playerType == PlayerTypeSO.PlayerType.Player)
        {
            TryGetPlayerFiles();
            if (motor_Script != null) motor_Script.enabled = true;
            if (jump_Script != null) jump_Script.enabled = true;
            if (dash_Script != null) dash_Script.enabled = true;
        }
        else if(settings.playerType == PlayerTypeSO.PlayerType.Shooter)
        {
            // TODO
        }

        inputManager = InputManager.Instance;
    }


    private void TryGetPlayerFiles()
    {
        if (TryGetComponent<Motor>(out Motor motor)) motor_Script = GetComponent<Motor>(); 
        if (TryGetComponent<Jump>(out Jump jump)) jump_Script = GetComponent<Jump>(); 
        if (TryGetComponent<Dash>(out Dash dash)) dash_Script = GetComponent<Dash>(); 
    }

    private void TryDisableShooterFiles()
    {
        // TODO
    }

    private void TryGetShooterFiles()
    {
        // TODOD
    }

}
