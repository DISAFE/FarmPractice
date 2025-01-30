using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private Vector3 power;
    private float damage;
    private float range;
    private float speed;
    

    public void Setting(Vector3 power, float damage, float range)
    {
        this.range = range;
        this.power = power;
        this.damage = damage;
        speed = 10.0f;
    }
    private void FixedUpdate()
    {
        if(range < 0) Destroy(transform.gameObject);
        transform.position += power * Time.fixedDeltaTime * speed;
        range -= power.magnitude * Time.fixedDeltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            Attack(collision);
            Destroy(transform.gameObject); // ÃÑ¾Ë »èÁ¦
        }
    }

    protected void Attack(Collider2D collision)
    {
        GameObject Monster = collision.gameObject.GetComponent<HPManager>().Attacked(damage);
    }
}