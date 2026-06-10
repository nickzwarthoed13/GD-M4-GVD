using UnityEngine;
using UnityEngine.InputSystem;

public class TiggerAni : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;

    private InputActionMap map;
    private InputAction moveAction;
    private InputAction jumpAction;

    [SerializeField] private float movespeed = 5f;

    private Animator animator;

    private void Awake()
    {
        map = input.FindActionMap("Player");
        moveAction = map.FindAction("move");
        jumpAction = map.FindAction("jump");

        animator = GetComponent<Animator>();
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
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float speed = moveInput.y * movespeed * Time.deltaTime;

        animator.SetFloat("Speed" , speed);

        if (jumpAction.WasReleasedThisFrame())
        {
            animator.SetTrigger("Jump");
        }
    }
}
