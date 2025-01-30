using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPManager : MonoBehaviour
{
    public UnityEvent OnEntityDead;
    private EntityData entityData;

    private void Awake()
    {
        OnEntityDead = new UnityEvent();
    }

    public void Attacked(float damage)
    {
        entityData.hp -= damage;
        if (entityData.hp <= 0)
        {
            Dead();
            OnEntityDead.Invoke();
        }
    }

    public void Heal(float heal)
    {
        entityData.hp += heal;
        if (entityData.hp > 100) entityData.hp = 100; 
    }

    private void Dead()
    {

    }
}
