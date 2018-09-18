using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float mouseSpeed = 3.0f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15.0f;
    public float terminalVelocity = -10.0f;
    public float minFall = -1.5f;
    public float pushForce = 3.0f;

    [SerializeField] private GameObject inventoryUI;

    private float _vertSpeed;

    private Vector3 movement = Vector3.zero;

    private CharacterController charCon;
    private ControllerColliderHit _contact;
    //private Animator anim;
    private float _s = 0f;

    private float rotY = 0;

    // Use this for initialization
    void Start()
    {
        charCon = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inventoryUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;

            movement = Vector3.zero;
            _s = 0f;

            float mouseX = Input.GetAxis("Mouse X") * mouseSpeed; // * Time.deltaTime;

            if (mouseX != 0)
            {
                rotY += mouseX;
                transform.localEulerAngles = new Vector3(0, rotY, 0f);
            }

            float horIn = Input.GetAxis("Horizontal") * moveSpeed;// * Time.deltaTime;
            float verIn = Input.GetAxis("Vertical") * moveSpeed;// * Time.deltaTime;
            if (horIn != 0 || verIn != 0)
            {
                movement = new Vector3(horIn, 0, verIn);
                movement = Vector3.ClampMagnitude(movement, moveSpeed);
                movement = transform.TransformDirection(movement);
                _s = moveSpeed;
            }

            bool hitGround = false;
            RaycastHit hit;
            if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                float check = (charCon.height + charCon.radius) / 1.9f;
                hitGround = hit.distance <= check;
            }

            if (hitGround)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _vertSpeed = jumpSpeed;
                }
                else
                {
                    _vertSpeed = -0.1f;
                    //_animator.SetBool("Jumping", false);
                }
            }
            else
            {
                _vertSpeed += gravity * 5 * Time.deltaTime;
                if (_vertSpeed < terminalVelocity)
                {
                    _vertSpeed = terminalVelocity;
                }
                // if (_contact != null)
                // {
                //     _animator.SetBool("Jumping", true);
                // }

                if (charCon.isGrounded)
                {
                    if (Vector3.Dot(movement, _contact.normal) < 0)
                    {
                        movement = _contact.normal * moveSpeed;
                    }
                    else
                    {
                        movement += _contact.normal * moveSpeed;
                    }

                }
            }

            movement.y = _vertSpeed;

            movement *= Time.deltaTime;


            //anim.SetFloat("Speed", _s);
            //movement.y = gravity;

            charCon.Move(movement);
        }else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;

        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null && !rb.isKinematic)
        {
            rb.velocity = hit.moveDirection * pushForce;
        }
    }
}
