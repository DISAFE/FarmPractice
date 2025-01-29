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
    [SerializeField] // �⺻�� �� ����
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

    void EquipSomething() // �̺�Ʈ ������ �κ��丮 �Ŵ������� ������ ������ �ٲ�
    {
        //GameObject newEquipped = InvenManager.GetEquipped // �κ��丮 �Ŵ������� �޾ƿ���
        Destroy(equipped); //���� ���۵� �� ����
        GameObject newEquipped = Instantiate(equipped); 
        newEquipped.transform.SetParent(transform, false);
        equipped = newEquipped;
    }
}
