using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject attackAnimation;
    [SerializeField]
    private LayerMask m_WhatToAttack;
    private Animator m_Animator;
    private bool m_Attacking;


    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    public void Attack()
    {
        m_Animator.SetTrigger("Attack");
        m_Attacking = true;
        while (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Viking_Attack_DefaultSword")) 
        {
            m_Attacking = true;
            Debug.Log("attacking");
        }
        
        //m_Attacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision.collider.gameObject: " + collision.collider.gameObject);
        //Debug.Log("collision.gameObject: " + collision.gameObject);
        //Debug.Log("collision.otherCollider.gameObject: " + collision.otherCollider.gameObject);
        //Debug.Log("collision.GetContact(0):" + collision.GetContact(0));
        //collision.gameObject;
        if (m_Attacking == true && collision.otherCollider.gameObject.tag == "Weapon") 
        {
            Debug.Log("destroy");
           // Destroy(collision.GetContacts(List<ContactPoint2D> contacts)[0].gameObject);
        }
    }
}
