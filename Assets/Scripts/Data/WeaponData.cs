using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObject/WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum Type
    {
        Normal, // 가장 기본 속성 추가 능력 없음
        Fire, // 높은 데미지와 지속적인 피해 (적을 불태움)
        Ice, // 적을 얼려서 속도 감소 및 공격 지연
        Lightning, // 빠른 다수 타격 및 스턴 효과
        Poison, // 지속적인 피해와 체력 회복 방해
        Wind, // 빠르고 민첩한 공격, 회피 또는 이동 속도 증가
        Light, // 언데드나 어두운 적에게 강한 피해, 회복 및 스턴 효과
        Darkness, // 체력 흡수 효과로 자신의 체력 회복
        Earth, // 강력한 물리적 타격과 기절 효과
        Time, // 공격 속도 또는 적의 행동 느리게, 시간 되돌리기 또는 강화
    }

    [Header("Info")]
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab;

    [Header("Stats")]
    public Type type;
    public float Damage;
    public float cooltime;

    [Header("handle")]
    public Vector3 pos = new(-0.2f, 0.2f, 0);
    public Quaternion ang = Quaternion.Euler(0, 0, -20);
    public Vector3 pos_r = new(0.2f, 0.2f, 0);
    public Quaternion ang_r = Quaternion.Euler(0, 0, 20);
}
