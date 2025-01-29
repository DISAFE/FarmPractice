using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

/*
 * 부모의 flip 상태에 따라서 그림 그리기 기능이 있음.
 * Shot만 오버로딩 하면 됨.
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
        if (!weaponIIsReloading) // 재장전 중일 때는 아무것도 못함.
        {
            if (Input.GetMouseButton(0))
            {
                power = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.Main.transform.position);
                power = power.normalized;
                CheckingShot(new Vector3(power.x, power.y, 0));
            }
            if (Input.GetKey(KeyCode.R) && Ammo != weaponData.MC) // 풀 충전이 아니라면 Reload
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void LateUpdate()
    {
        Drawing();
    }

    protected virtual void Shot(Vector3 power) // 오버라이드
    {
    }

    private void Drawing()
    {
        if (parentSprite.flipX) // 부모가 좌우반전이라면
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
        
        if(Ammo == 0) // 총알이 없다면
        {
            Debug.Log("Ammo 0");
            StartCoroutine(Reload());
        }
        else if(!weaponIsCoolling)// 쏠 수 있는 상황이라면
        {
            Shot(power);
            StartCoroutine(Coolling());
        }

    }
    public IEnumerator Reload()
    {
        // 재장전 사운드
        // 재장전 UI

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
