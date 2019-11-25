﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    public Spawner spaw;
    Vector3 direction;

    public void Move(Vector3 dir)
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
        spaw.ReturnHPool(this.gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DZ"))
        {
            Destroy();
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy();
        }
    }

}
