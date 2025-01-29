using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public static Player Main;

    [Header("Componants")]
    private SpriteRenderer playerRenderer;
    private Animator animator;
    private Camera mainCamera;

    [Header("Hands")]
    [SerializeField] // 기본은 총 장착
    private GameObject equipped;

    [Header("Values")]
    private float normalSpeed;
    private RaycastHit hit;

    [Header("Input")]
    private Vector3 playerInput;
    private Vector3 mousePoint;


    private void Awake()
    {
        Main = this;
        normalSpeed = 3.0f;
        playerRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Walk();
    }
    void LateUpdate()
    {
        animator.SetFloat("Speed", playerInput.magnitude);
        mousePoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        playerRenderer.flipX = transform.position.x - mousePoint.x > 0;
        
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

    void EquipSomething() // 이벤트 리스너 인벤토리 매니저에서 장착을 누르면 바뀜
    {
        //GameObject newEquipped = InvenManager.GetEquipped // 인벤토리 매니저에서 받아오기
        Destroy(equipped); //현재 장작된 것 삭제
        GameObject newEquipped = Instantiate(equipped); 
        newEquipped.transform.SetParent(transform, false);
        equipped = newEquipped;
    }
}
