using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TiggerAni : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;

    private InputActionMap map;
    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    [SerializeField] private float movespeed = 5f;

    private Animator animator;

    private void Awake()
    {
        map = input.FindActionMap("Player");
        moveAction = map.FindAction("Move");
        sprintAction = map.FindAction("Sprint");
        jumpAction = map.FindAction("Jump");

        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        map.Enable();
    }

    private void OnDisable()
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
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        //transform.Translate(moveInput.y * transform.forward * Time.deltaTime * 300f, Space.World);

        float speed = moveInput.y * movespeed * Time.deltaTime;
        Debug.Log(speed);
        animator.SetFloat("speed" , speed);

        if (sprintAction.IsPressed())
        {
            animator.SetFloat("Speed", 10);
        }

        if (jumpAction.WasPressedThisFrame())
        {
            animator.SetTrigger("Jump");
        }
    }
}
