using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Character_Controller : MonoBehaviour
{
    private PlayerInputActions playerControls;
    private Rigidbody2D rb;

    public float MovementSpeed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new PlayerInputActions();
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
        Vector2 movement = playerControls.Player.Move.ReadValue<Vector2>() * MovementSpeed;
        rb.linearVelocity = movement;
    }

    private void OnDisable() {
        playerControls.Player.Disable();
    }
}
