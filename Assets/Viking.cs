using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.UIElements;

public class Viking : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public bool running;
    public bool attacking;

    void Start()
    {
    
    }

    IEnumerator reloadAttacking()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(60);

        //After we have waited 5 seconds print the time again.
        attacking = false;
        GetComponent<UnityArmatureComponent>().animation.Play("Idle");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            GetComponent<UnityArmatureComponent>().animation.Play("Jump");
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            //transform.eulerAngles = new Vector3(0, 0, 0); // Normal
            
            if (running == false)
            {
                GetComponent<UnityArmatureComponent>().animation.Play("Run");
                running = true;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && attacking == false) 
        {
            GetComponent<UnityArmatureComponent>().animation.Play("Attack");
            attacking = true;
            reloadAttacking();
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            //transform.eulerAngles = new Vector3(0, 180, 0); // Flipped

            if (running == false)
            {
                GetComponent<UnityArmatureComponent>().animation.Play("Run");
                running = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) /*|| Input.GetKeyUp(KeyCode.Mouse0)*/ )
        {
           GetComponent<UnityArmatureComponent>().animation.Play("Idle");
           running = false;
           //attacking = false;
        }
    }
}