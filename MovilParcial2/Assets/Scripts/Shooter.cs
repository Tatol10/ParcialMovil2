using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    private int initbullet;
    private ObjectPool bulletPool;
    private bool canShoot;


    private void Awake()
    {
        bulletPool = new ObjectPool(initbullet, bullet);
    }


    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // Retrieve Input
       
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }

#endif
#if UNITY_ANDROID && !UNITY_EDITOR
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                Shoot();
            }
        }
#endif
    }

    void Shoot()
    {
        if (FindObjectOfType<GameLogic>().lost == false)
        {
            if (FindObjectOfType<GameLogic>().Ammo())
            {
                GameObject gob = bulletPool.GetPooledObject();
                gob.transform.position = this.transform.position;
                gob.SetActive(true);
                Bullet b = gob.GetComponent<Bullet>();
                b.shooter = this;
                b.Shoot(this.transform.forward);
                FindObjectOfType<GameLogic>().curretAmmo--;
            }
        }
    }
    public void ReturnPool(GameObject bulletReturn)
    {
        bulletReturn.SetActive(false);
        bulletPool.PushObj(bulletReturn);
    }
  
}
