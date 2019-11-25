using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    public Shooter shooter;
    Vector3 direction;
    public void Shoot(Vector3 dir)
    {
        direction = dir;
        this.transform.up = dir;
    }

    void Update()
    {
        Vector3 pos = this.transform.position;

        pos += direction * speed * Time.deltaTime;

        this.transform.position = pos;
    }

    void Destroy()
    {
        shooter.ReturnPool(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy();
        }
        if (other.gameObject.CompareTag("Scenery"))
        {
            Destroy();
        }
    }

}
