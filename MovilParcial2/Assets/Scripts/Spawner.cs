using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int initEnemy;
    [SerializeField]
    private int initAmmo;
    [SerializeField]
    private int initHeal;
    private ObjectPool enemyPool;
    private ObjectPool ammoPool;
    private ObjectPool healPool;
    public GameObject trif;
    public GameObject greed;
    public GameObject heal;
    public bool stopSpawning = false;
    public float spawTime;
    public float spawDelay;
    public int random;

    // Start is called before the first frame update
    void Start()
    {
        enemyPool = new ObjectPool(initEnemy, trif);
        ammoPool = new ObjectPool(initAmmo, greed);
        healPool = new ObjectPool(initHeal, heal);
        InvokeRepeating("Spawn", spawTime, spawDelay);
    }

    public void Spawn()
    {
        //Instantiate(trif, transform.position, transform.rotation);
        random = Random.Range(1, 6);
        switch(random)
        {
            case 1:
                SpawnA();
                break;
            case 2:
                SpawnH();
                break;
            default:
                SpawnE();
                break;
        }
        if (stopSpawning)
            CancelInvoke("Spawn");
    }
    void SpawnE()
    {
        GameObject go = enemyPool.GetPooledObject();
        go.transform.position = this.transform.position;
        go.SetActive(true);
        Enemy e = go.GetComponent<Enemy>();
        e.spaw = this;
        e.Move(this.transform.up);
    }
    public void ReturnEPool(GameObject objReturn)
    {
        objReturn.SetActive(false);
        enemyPool.PushObj(objReturn);
    }
    void SpawnH()
    {
        GameObject goh = healPool.GetPooledObject();
        goh.transform.position = this.transform.position;
        goh.SetActive(true);
        Heal h = goh.GetComponent<Heal>();
        h.spaw = this;
        h.Move(this.transform.up);
    }
    public void ReturnHPool(GameObject objReturn)
    {
        objReturn.SetActive(false);
        healPool.PushObj(objReturn);
    }
    void SpawnA()
    {
        GameObject goa = ammoPool.GetPooledObject();
        goa.transform.position = this.transform.position;
        goa.SetActive(true);
        Ammo a = goa.GetComponent<Ammo>();
        a.spaw = this;
        a.Move(this.transform.up);
    }
    public void ReturnAPool(GameObject objReturn)
    {
        objReturn.SetActive(false);
        ammoPool.PushObj(objReturn);
    }
}
