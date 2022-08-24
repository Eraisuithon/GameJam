using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGun : MonoBehaviour
{
    public float scale = 100f;
    public GameObject shooter;

    void OnGUI()
    {
        float angle = Input.mouseScrollDelta.y * scale;
        transform.Rotate(0, 0, angle);

    }
}
