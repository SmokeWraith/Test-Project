using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
	private CharacterController controller; 
//reference to character controller component on player object

    [Header("Movement Settings")]
	[SerializeField] private float walkSpeed = 5f; 
//How fast the character walks

    [Header("Input")]
	private float moveInput; //Forwards and Backwards
	private float turnInput; //Side to Side Direction

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
//Get the Character Controller on Player Object
	Debug.Log("Initializing Controller");
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
	    Movement();
    }

    private void Movement()
    {  
    	GroundMovement();
        //TurnPlayer();
    }

    private void GroundMovement ()
    {  
    	Vector3 move = new Vector3(turnInput, 0, moveInput); 
//Vector3 that stores input from player in format character controller needs.

	move.y = 0; 
//Clamp Player to Ground
	
	move *= walkSpeed; 
//Multiply Walkspeed by Vector
	
	controller.Move(move * Time.deltaTime); 
//Move Character by Amount in the Move Vector times Time Elapsed
    }
    
    /*private void TurnPlayer()
 * { 
 *  if (Mathf.Abs(turnInput) > 0 || Mathf.Abs(moveInput <= 0) //Only Allow the Player to Turn the Character when Moving
 *  {
 *      Vector3 currentLookDirection = controller.velocity.normalized; //Set the Look Direction to Direction Player is Currently Travelling
 *      currentLookDirection.y = 0;
 *      
 *      currentLookDirection.Normalize();
 *      
 *      if (currentLookDirection.sqrMagnitude <= 0)
 *      {
 *          return;
 *      }
 *      
 *      Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection); //Quaternion that sets the end Target for Player Character Rotation to the Direction of the Player
 *                                                                                 //in the Direction Player has Turned the Camera
 *      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turningSpeed); //Smoothly interpolate the player character's rotation from current
 *                                                                                                                //to the Direction Player has Turned the Camera to
 *  }
 * }
 */

    /*
     *  private float VerticalForceCalculation()
     *  {
     *      if(controller.isGrounded)
     *      {
     *          verticalVelocity = -1f;
     *          
     *          if(Input.GetButtonDown("Jump"))
     *          {
     *              verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2); //Launches the player into the air based on jumpheight and gravity calculated.
     *          }
     *      }
     *      else
     *      {
     *          verticalVelocity -= gravity * Time.deltaTime; //If Player is not on the Ground, the Pull them Downwards at the Speed of Gravity
     *      }
     */

    private void ProcessInput() 
//Grabs Player Input from Unity's Built In Input Manager
    {  
    	moveInput = Input.GetAxis("Vertical");
    	turnInput = Input.GetAxis("Horizontal");
    }

   
}
