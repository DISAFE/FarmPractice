using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer playerRendering;
    private Animator animator;

    private float normalSpeed;
    private Vector3 playerInput;
    private RaycastHit hit;
    

    private void Awake()
    {
        normalSpeed = 3.0f;
    }

    void Start()
    {
        playerRendering = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Walk();
    }
    void LateUpdate()
    {
        animator.SetFloat("Speed", playerInput.magnitude);

        if (playerInput.x != 0)
        {
            playerRendering.flipX = playerInput.x < 0;
        }
    }

    void Walk()
    {
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");
        playerInput = playerInput.normalized;
        playerInput = playerInput * normalSpeed * Time.fixedDeltaTime;
        if (!Physics2D.Raycast(transform.position, playerInput, 0.5f, (1 << 6) + (1 << 8) + (1 << 9)))
        {
            transform.position += playerInput;
        }
    }
}
