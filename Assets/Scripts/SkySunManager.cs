using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySunManager : MonoBehaviour {
    public GameObject sunProfab;
    private GameObject sun;

    private float createSunPosY = 6;

    // 5.5 ~ -5.5
    private float finalPosX;

    //¯ó¥Ö¤W 2.5 ~ -3.7
    private float finalPosY;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("createSun", 3, 6);
    }

    // Update is called once per frame
    void Update() {
    
    }

    void createSun() {
        finalPosY = Random.Range(-3.7f, 2.5f);
        finalPosX = Random.Range(-5.5f, 5.5f);
        sun = Instantiate(sunProfab);
        Sun sunscript = sun.GetComponent<Sun>();
        sunscript.Init(new Vector2(finalPosX, createSunPosY), finalPosY);
    }
}
