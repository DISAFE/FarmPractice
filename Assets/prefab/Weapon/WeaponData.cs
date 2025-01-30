using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObject/WeaponData")]
public class WeaponData : InfoData
{
    [Header("WeaponInfo")]
    public Sprite icon;
    public GameObject prefab_weapon;
    public GameObject prefab_bullet;

    [Header("Stats")]
    public float damage = 0; // 데미지
    public float cooltime = 0; // 쿨타임
    public float reloadtime = 0; // 재장전 시간
    public float range = 0; // 사거리
    public int MC = 0; // 탄창

    [Header("Handle")] // 손 위치 포지션
    public Vector3 pos = new(-0.2f, 0.2f, 0);
    public Quaternion ang = Quaternion.Euler(0, 0, -20);
    public Vector3 pos_r = new(0.2f, 0.2f, 0);
    public Quaternion ang_r = Quaternion.Euler(0, 0, 20);

    [Header("Muzzle")]
    public Vector3 muzzle;
    public Vector3 muzzle_r;
}
