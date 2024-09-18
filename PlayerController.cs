using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	private CharacterInput controls; // Our controls we defined
    private Vector3 velocity; // To hold our current velocity
    private Vector2 move; // To hold our move
    

    private CharacterController controller; // Character controller

    public float moveSpeed = 6f; // To calibrate our movement
    public float jumpHeight = 2.4f; // To calibrate our jump
    public float gravity = -9.81f; // To calibrate our gravity

    public Transform ground; // Ground check empty goes in here
    public float distanceToGround = 0.4f; // How close the ground needs to be to register
    public LayerMask groundMask; // What layer is ground?
	
    void Awake()
    {
		controls = new CharacterInput();
		controller = GetComponent<CharacterController>();
    }

    void Update()
    {
		PlayerMovement();
		Grav();
		Jump();
    }

    private void Grav()
    {
		if (isGrounded() && velocity.y < 0){
			velocity.y = -2f;
		}
		
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
    }

    private bool isGrounded()
    {
		return Physics.CheckSphere(ground.position, distanceToGround, groundMask);
    }

    private void PlayerMovement()
    {
		move = controls.Player.Movement.ReadValue<Vector2>();
		
		Vector3 movement = (move.y * transform.forward) + (move.x * transform.right);
		controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
		if (controls.Player.Jump.triggered && isGrounded()){
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
    }

    void OnEnable()
    {
		controls.Enable();
    }

    void OnDisable()
    {
		controls.Disable();
    }
}
