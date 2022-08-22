using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerManager manager;

    private void Awake()
    {
        manager = GetComponent<PlayerManager>();
        print(manager.motor_Script.transform.name);
        print(manager.jump_Script.transform.name);
        print(manager.dash_Script.transform.name);
    }
}