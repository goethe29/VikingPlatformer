using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour {

    private PlayerMovement c_movement;  //Reference to PlayerMovement script
    private Attacking c_attacking;
    private bool isJumping;             //To determine if the player is jumping
	
	void Awake()
    {
        //References
        c_movement = GetComponent<PlayerMovement>();
        c_attacking = GetComponent<Attacking>();
    }
	
	void Update ()
    {
        //If he is not jumping...
	    if (!isJumping)
        {
            //See if button is pressed...
            isJumping = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            c_attacking.Attack();
        }
	}

    private void FixedUpdate()
    {
        //Get horizontal axis
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //if (h != 0)
        //    debug.log(h);
        //Call movement function in PlayerMovement
        c_movement.Move(h, isJumping);
        //Reset
        isJumping = false;
    }
}
