using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoData : ScriptableObject
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
    public string name = "null"; // �̸�
    public string description = "null"; // ����

    [Header("Stats")]
    public Type type = Type.Normal; // �Ӽ�
}
