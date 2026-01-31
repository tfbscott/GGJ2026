using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Character_Controller : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private Rigidbody2D rb;
    private Animator animator;

    public float MovementSpeed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();

        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        playerControls.Player.Enable();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();

        animator.SetBool("Walking", move.magnitude > 0.01f);

        rb.linearVelocity = move * MovementSpeed;
    }

    private void OnDisable() {
        playerControls.Player.Disable();
    }
}
