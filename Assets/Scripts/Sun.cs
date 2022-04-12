using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {
    private float finalPosY;

    SpriteRenderer sunColor;

    private Status status;
    public enum Status {
        sky,
        flower
    }
    private void Start() {
        sunColor = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void FixedUpdate() {
        sunDown();
    }

    private void ControlStatus() {
        switch (status) {
            case Status.sky:
                //sunDown();
                print("sky模式");
                break;
            case Status.flower:
                //jumpAni();
                print("flower模式");
                break;
        }
    }

    void sunDown() {
        if (this.transform.position.y <= finalPosY) {
            Invoke("loseSun", 3f);
            return;
        }
        this.transform.Translate(Vector2.down * Time.deltaTime);
    }

    private void Awake() {
        //ControlStatus();
    }
    //降落太陽初始化
    public void Init(Vector2 pos, float final) {
        this.transform.position = pos;
        //天降模式
        status = Status.sky;
    }

    //太陽花彈跳初始化
    public void Init(Vector2 pos) {
        this.transform.position = pos;
        finalPosY = 10;
        //彈跳模式
        status = Status.flower;
    }


    private void loseSun() {
        sunColor.color = new Color(1, 1, 1, sunColor.color.a * 0.95f);
        if (sunColor.color.a <= 0.1f)
            Destroy(this.gameObject);
    }

    private void OnMouseDown() {
        PlayerManager.Instance.sunNum += 50;
        Vector3 numTextPos = Camera.main.ScreenToWorldPoint(UIManager.Instance.getSunNumTextPos());
        numTextPos = new Vector3(numTextPos.x, numTextPos.y, 0f);
        flyAni(numTextPos);
    }

    private void flyAni(Vector3 numTextPos) {
        StartCoroutine(doFly(numTextPos));
    }

    private IEnumerator doFly(Vector3 numTextPos) {
        Vector3 direction = (numTextPos - this.transform.position).normalized;
        while (Vector3.Distance(numTextPos, this.transform.position) > 1f) {
            yield return new WaitForSeconds(0.03f);
            this.transform.Translate(direction);
        }
        Destroy(this.gameObject);
    }

    public void jumpAni() {
        StartCoroutine(doJump());
    }

    private IEnumerator doJump() {
        bool isLeft = Random.Range(0, 2) == 0 ? true : false;
        Vector3 startPos = this.transform.position;
        if (isLeft) {
            while (this.transform.position.y < startPos.y + 1) {
                this.transform.Translate(new Vector3(0.01f, 0.05f, 0));
                yield return new WaitForSeconds(0.005f);
            }
            while (this.transform.position.y >= startPos.y) {
                this.transform.Translate(new Vector3(0.01f, -0.05f, 0));
                yield return new WaitForSeconds(0.01f);
            }
        }
        else {
            while (this.transform.position.y < startPos.y + 1) {
                this.transform.Translate(new Vector3(-0.01f, 0.05f, 0));
                yield return new WaitForSeconds(0.005f);
            }
            while (this.transform.position.y >= startPos.y) {
                this.transform.Translate(new Vector3(-0.01f, -0.05f, 0));
                yield return new WaitForSeconds(0.01f);
            }

        }
    }
}
