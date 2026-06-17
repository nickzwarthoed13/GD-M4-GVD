using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class player : MonoBehaviour
{

    [SerializeField] private InputActionAsset input;
    [SerializeField] private string actionMapName = "Player1";

    private InputActionMap map;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private CharacterController cc;
    private Rigidbody rb;
    public float turnSpeed = 3f;
    public float moveSpeed = 0.25f;

    void Awake()
    {
        map = input.FindActionMap(actionMapName);
        moveAction = map.FindAction("Move");
        jumpAction = map.FindAction("Jump");
        sprintAction = map.FindAction("Sprint");
    }
    void Onable()
    {
        map.Enable();
    }

    void Osable()
    {
        map.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        transform.rotation *= quaternion.Euler(0, moveInput.x * turnSpeed * Time.deltaTime, 0);
        if (sprintAction.IsPressed())
        {
            transform.position += transform.forward * moveInput.y * moveSpeed * 2 * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * moveInput.y * moveSpeed * Time.deltaTime;
        }

        //float currentMoveSpeed = moveInput.y * moveSpeed * Time.deltaTime;

        //cc.Move(transform.forward * currentMoveSpeed);


        //transform.Translate(moveInput.y * transform.forward * Time.deltaTime * 5f, Space.World);
        //transform.Rotate(Vector3.up, moveInput.x * Time.deltaTime * 100f, Space.Self);

        //animator.SetFloat("Speed", currentMoveSpeed);

        if (jumpAction.WasPressedThisFrame())
        {
            rb.linearVelocity += new Vector3(0, 5, 0);
        }

    }

}