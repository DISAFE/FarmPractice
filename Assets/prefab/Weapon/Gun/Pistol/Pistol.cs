using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    protected override void Shot(Vector3 power)
    {
        GameObject bullet = Instantiate(weaponData.prefab_bullet);
        bullet.transform.position = transform.position + (mySprite.flipX ? weaponData.muzzle_r : weaponData.muzzle);
        bullet.GetComponent<Bullet>().Setting(power, weaponData.damage, weaponData.range);
        Ammo--;
    }
}
