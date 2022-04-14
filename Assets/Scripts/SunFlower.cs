using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : PlantBase
{
    public float firstCreateSunTime = 0;
    public float repeatCreateSunTime = 3;
    private float goldTime = 1;

    SpriteRenderer sunflowerRender;

    public override void init() {
        sunflowerRender = this.GetComponent<SpriteRenderer>();
        InvokeRepeating("createSun", firstCreateSunTime, repeatCreateSunTime);
    }

    private void createSun() {
        StartCoroutine(DoCreateSun());
    }

    IEnumerator DoCreateSun() {
        float nowTime = 0;
        while (nowTime <= goldTime) {
            yield return new WaitForSeconds(0.05f);
            nowTime += 0.05f;
            float lerp = nowTime / goldTime;
            sunflowerRender.color = Color.Lerp(Color.white,new Color(1f,0.35f,0),lerp);
        }
        sunflowerRender.color = Color.white;
        GameObject sun = Instantiate(Stash.Instance.GameConf.sun);
        
        Sun sunscript = sun.GetComponent<Sun>();
        sunscript.Init(this.transform.position);
        sunscript.jumpAni();
    }
}
