using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    public GameObject sunProfab;

    private void Awake() {
        InvokeRepeating("createSun", 3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createSun() {
        GameObject sun = Instantiate(sunProfab);
        Sun sunscript = sun.GetComponent<Sun>();
        sunscript.Init(this.transform.position);
        sunscript.jumpAni();
    }
}
