using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObject/WeaponData")]
public class WeaponData : ScriptableObject
{
    public enum Type
    {
        Normal, // ���� �⺻ �Ӽ� �߰� �ɷ� ����
        Fire, // ���� �������� �������� ���� (���� ���¿�)
        Ice, // ���� ����� �ӵ� ���� �� ���� ����
        Lightning, // ���� �ټ� Ÿ�� �� ���� ȿ��
        Poison, // �������� ���ؿ� ü�� ȸ�� ����
        Wind, // ������ ��ø�� ����, ȸ�� �Ǵ� �̵� �ӵ� ����
        Light, // �𵥵峪 ��ο� ������ ���� ����, ȸ�� �� ���� ȿ��
        Darkness, // ü�� ��� ȿ���� �ڽ��� ü�� ȸ��
        Earth, // ������ ������ Ÿ�ݰ� ���� ȿ��
        Time, // ���� �ӵ� �Ǵ� ���� �ൿ ������, �ð� �ǵ����� �Ǵ� ��ȭ
    }

    [Header("Info")]
    public string name;
    public string description;
    public Sprite icon;
    public GameObject prefab_weapon;
    public GameObject prefab_bullet;

    [Header("Stats")]
    public Type type; // �Ӽ�
    public float damage; // ������
    public float cooltime; // ��Ÿ��
    public float reloadtime; // ������ �ð�
    public float range; // ��Ÿ�
    public int MC; // źâ

    [Header("Handle")] // �� ��ġ ������
    public Vector3 pos = new(-0.2f, 0.2f, 0);
    public Quaternion ang = Quaternion.Euler(0, 0, -20);
    public Vector3 pos_r = new(0.2f, 0.2f, 0);
    public Quaternion ang_r = Quaternion.Euler(0, 0, 20);

    [Header("Muzzle")]
    public Vector3 muzzle;
    public Vector3 muzzle_r;
}
