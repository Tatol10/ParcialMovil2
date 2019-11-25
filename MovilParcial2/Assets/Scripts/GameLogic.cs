using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private float startTime;
    public bool lost = false;
    private string minutes;
    private string seconds;
    public int curretAmmo;
    public Text lpText;
    public int lp;
    public Text loseText;
    public Text timerText;
    public Text ammoText;
    public int maxAmmo = 10;
    


    // Start is called before the first frame update
    void Start()
    {
        lp = 8000;
        startTime = Time.time;
        curretAmmo = maxAmmo;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (lost != true)
        {
            float t = Time.time - startTime;

            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
            ammoText.text = curretAmmo + " /10";
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (lost != true)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                lp -= 800;
            }
            if (other.gameObject.CompareTag("Heal"))
            {
                lp += 800;
            }
            if (other.gameObject.CompareTag("Ammo"))
            {
                curretAmmo = maxAmmo;
            }
            SetCountText();
        }
    }
    public void SetCountText()
    {
        lpText.text = "Life Point: " + lp.ToString();
        if (lp <= 0)
        {
            lost = true;
            GameOver();
        }
    }
    public bool Ammo()
    {
        if (curretAmmo <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    void GameOver()
    {
        loseText.text = "You Lost";
        timerText.text = "Final Time " + minutes + ":" + seconds;
    }
}
