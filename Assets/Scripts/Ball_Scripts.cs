using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball_Scripts : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public float hiz = 1.5f;
    private Rigidbody rg;
    public UnityEngine.UI.Text time, health,durum;
    float timer = 60f;
    int healther = 10;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam) 
        { 
        timer -= Time.deltaTime;
        time.text = (int)timer+"";
        health.text = healther + "";
        }
        else if(!oyunTamam)
        {
            durum.text = "Kaybettin!";
            btn.gameObject.SetActive(true);
        }
        if (timer < 0 || healther < 0)
        {
            oyunDevam = false;
        }
    }
    void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam) 
        { 
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
        rg.AddForce(kuvvet* hiz);
        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision cls)
    {
        string ObjName = cls.gameObject.name;
        if (ObjName.Equals ("finish"))
        {
            //print("Oyun Kazanýldý");
            oyunTamam = true;
            durum.text = "Kazandýn Tebrikler!";
            btn.gameObject.SetActive(true);
        }
        else if(!ObjName.Equals ("Plane"))
        {
            healther -= 1;
            health.text = healther + "";
        }
        if (healther < 0)
        {
            oyunDevam = false;
        }
    }
   
}
