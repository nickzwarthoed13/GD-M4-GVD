using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerAni : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    private InputActionMap map;
    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    [SerializeField] private float moveSpeed = 5f;
    private Animator ani;


    void Awake()
    {
        map = input.FindActionMap("Player");
        moveAction = map.FindAction("Move");
        sprintAction = map.FindAction("Sprint");
        jumpAction = map.FindAction("Jump");

        ani = GetComponent<Animator>();
    }
    void Onable()
    {
        map.Enable();
    }
    void Osable()
    {
        map.Disable();
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveImput = moveAction.ReadValue<Vector2>();
        float speed = moveImput.y * moveSpeed * Time.deltaTime;

        ani.SetFloat("speed", speed);

        if (sprintAction.IsPressed())
        {
            ani.SetFloat("speed", 10);
        }

        if (jumpAction.WasPressedThisFrame())
        {
            ani.SetTrigger("jump");
        }
    }
}