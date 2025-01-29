using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField]
    private WeaponData weaponData;
    [SerializeField]
    private GameObject bullet;
    private SpriteRenderer playerSprite;
    private SpriteRenderer mySprite;
    


    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerSprite = Player.Main.GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        if(playerSprite.flipX)
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
}
