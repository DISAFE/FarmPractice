using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    protected override void Shot(Vector3 power)
    {
        Debug.Log(power);
        for(int i = 0; i < 5; i++)
        {
            GameObject bullet = Instantiate(weaponData.prefab_bullet);
            bullet.transform.position = transform.position + weaponData.muzzle;
            bullet.GetComponent<Bullet>().Setting(NoisePower(power), weaponData.damage, weaponData.range);
        }
        Ammo--;
    }

    private Vector3 NoisePower(Vector3 power)
    {
        float angle = Mathf.Atan2(power.y, power.x);
        angle += Random.Range(-5, 5) * Mathf.Deg2Rad;
        Debug.Log(angle);
        return new Vector3(Mathf.Cos(angle),Mathf.Sin(angle), 0);
    }
} 
