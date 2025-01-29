using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

/*
 * �θ��� flip ���¿� ���� �׸� �׸��� ����� ����.
 * Shot�� �����ε� �ϸ� ��.
 */

public class Gun : MonoBehaviour
{
    [SerializeField]
    protected WeaponData weaponData;
    protected SpriteRenderer mySprite;
    protected SpriteRenderer parentSprite;
    protected CircleCollider2D range;

    protected bool weaponIsCoolling = false;
    protected bool weaponIIsReloading = false;
    protected int Ammo;

    private Vector2 power;

    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
        parentSprite = GetComponentsInParent<SpriteRenderer>()[1];
        range = GetComponent<CircleCollider2D>();
        Ammo = weaponData.MC;
    }

    private void Start()
    {
        Drawing();
        SetRange();
    }

    private void Update()
    {
        if (!weaponIIsReloading) // ������ ���� ���� �ƹ��͵� ����.
        {
            if (Input.GetMouseButton(0))
            {
                power = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.Main.transform.position);
                power = power.normalized;
                CheckingShot(new Vector3(power.x, power.y, 0));
            }
            if (Input.GetKey(KeyCode.R) && Ammo != weaponData.MC) // Ǯ ������ �ƴ϶�� Reload
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void LateUpdate()
    {
        Drawing();
    }

    protected virtual void Shot(Vector3 power) // �������̵�
    {
    }

    private void Drawing()
    {
        if (parentSprite.flipX) // �θ� �¿�����̶��
        {
            mySprite.flipX = true;
            transform.localPosition = weaponData.pos_r;
            transform.localRotation = weaponData.ang_r;
        }
        else 
        {
            mySprite.flipX = false;
            transform.localPosition = weaponData.pos;
            transform.localRotation = weaponData.ang;
        }
    }
    public void CheckingShot(Vector3 power)
    {
        
        if(Ammo == 0) // �Ѿ��� ���ٸ�
        {
            Debug.Log("Ammo 0");
            StartCoroutine(Reload());
        }
        else if(!weaponIsCoolling)// �� �� �ִ� ��Ȳ�̶��
        {
            Shot(power);
            StartCoroutine(Coolling());
        }

    }
    public IEnumerator Reload()
    {
        // ������ ����
        // ������ UI

        weaponIIsReloading = true;

        yield return new WaitForSecondsRealtime(weaponData.reloadtime);
        Ammo = weaponData.MC;

        weaponIIsReloading = false;
    }

    private IEnumerator Coolling()
    {
        weaponIsCoolling = true;
        yield return new WaitForSecondsRealtime(weaponData.cooltime);
        weaponIsCoolling = false;
    }
    
    private void SetRange()
    {
        range.radius = weaponData.range;
    }
}
