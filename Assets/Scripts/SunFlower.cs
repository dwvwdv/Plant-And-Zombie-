using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    public void init() {
        InvokeRepeating("createSun", 3, 5);
    }

    private void createSun() {
        GameObject sun = Instantiate(Stash.Instance.GameConf.sun);
        Sun sunscript = sun.GetComponent<Sun>();
        sunscript.Init(this.transform.position);
        sunscript.jumpAni();
    }
}
