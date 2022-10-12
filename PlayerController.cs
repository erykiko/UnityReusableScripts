using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool canMove = false; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate() {
        Move();
    }
    void Move(){
        if(!canMove) return;
        
        float moveX = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("move", Mathf.Abs(moveX));

        if(!Mathf.Approximately(0f, moveX))
        {
            transform.rotation = moveX < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        transform.position += new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;
    }
}
