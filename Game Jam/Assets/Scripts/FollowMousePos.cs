using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowMousePos : MonoBehaviour
{
    public enum MODE { UPDATE, LATEUPDATE, FIXEDUPDATE }
    public MODE mode;
    public bool RigidbodyFollow;
    public bool RigidbodyMovePos;
    public float followSpeed;
    Vector2 mouseWorldPos;
    Camera cam;
    InputManager input;
    Rigidbody2D rb;

    private void Awake()
    {
        cam = Camera.main;
        Cursor.visible = false;
        input = InputManager.Instance;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mouseWorldPos = Helper.Helpers.GetWorldPosition(input.GetMousePos(), cam);

        if (mode == MODE.UPDATE)
        {
            if (RigidbodyFollow && rb != null)
            {
                if (RigidbodyMovePos)
                {
                    rb.MovePosition(
                        rb.position + followSpeed * Time.deltaTime * (mouseWorldPos - rb.position));
                }
                else rb.position = mouseWorldPos;
            }
            else
            {
                transform.position = mouseWorldPos;
            }
        }
    }

    private void LateUpdate()
    {
        if (RigidbodyFollow && rb != null)
        {
            if (RigidbodyMovePos)
            {
                rb.MovePosition(
                    rb.position + followSpeed * Time.deltaTime * (mouseWorldPos - rb.position));
            }
            else rb.position = mouseWorldPos;
        }
        else
            transform.position = mouseWorldPos;
    }

    private void FixedUpdate()
    {
        if (RigidbodyFollow && rb != null)
        {
            if (RigidbodyMovePos)
            {
                rb.MovePosition(
                    rb.position + followSpeed * Time.deltaTime * (mouseWorldPos - rb.position));
            }
            else rb.position = mouseWorldPos;
        }
        else
            transform.position = mouseWorldPos;
    }

}
