using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static float speed = 4f;
    public static float jumpSpeed = 8f;
    public static float gravity = 20f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    [SerializeField] bool isInUncrouchableTrigger = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir = moveDir * speed;

            if (Input.GetKey(KeyCode.LeftControl))
            {
                controller.height = 1.2f;
            }
            else 
            {
                if (!isInUncrouchableTrigger)
                {
                    controller.height = 2.0f;
                }
                else controller.height = 1.2f;
            } 
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            moveDir.y = jumpSpeed;
        }

        moveDir.y = moveDir.y - gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UnCrouchableTrigger")
        {
            isInUncrouchableTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "UnCrouchableTrigger")
        {
            isInUncrouchableTrigger = false;
        }
    }
}