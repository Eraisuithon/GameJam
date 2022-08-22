using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerManager manager;
    InputManager inputManager;

    private void Start()
    {
        manager = GetComponent<PlayerManager>();
        inputManager = InputManager.Instance;
    }

}