using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private InputActionAsset input;
    [SerializeField] private string actionMapName = "Player1";

    private InputActionMap map;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    [SerializeField] private Rigidbody rb;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.WasPressedThisFrame())
        {
            Debug.Log("Jump Pressed");

        }
        else if (jumpAction.IsPressed())
        {
            Debug.Log("Jump held");
        }
        else if (jumpAction.WasReleasedThisFrame())
        {
            Debug.Log("Jump Released");

            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(moveInput.y * transform.forward * Time.deltaTime * 5f, Space.World);
        transform.Rotate(Vector3.up, moveInput.x * Time.deltaTime * 100f);

    }

}