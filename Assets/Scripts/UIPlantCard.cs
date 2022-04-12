using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPlantCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private Image maskImg;
    public GameObject profabPlant;

    private GameObject plant;

    public float CDTime = 10;

    public float nowCDTime;

    private bool _isPlace;
    public bool IsPlace {
        get => _isPlace;
        set {
            _isPlace = value;
            if (!_isPlace) {
                CDEnter();
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData) {
        if (IsPlace)
            transform.localScale = new Vector3(1.05f, 1.05f, 1);
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (IsPlace)
            transform.localScale = new Vector3(1f, 1f, 1f);
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start() {
        maskImg = transform.Find("Mask").GetComponent<Image>();
        IsPlace = false;
    }

    void CDEnter() {
        maskImg.fillAmount = 1f;
        StartCoroutine(calCD());
    }

    void placePlant() {
        plant.transform.position = GridManager.Instance.getGridPointByMouse();
        IsPlace = false;
    }

    void movePlant() {
        Vector2 v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        plant.transform.position = v2;
    }

    void createCardPlant() {
        if (!IsPlace)
            return;
        //if(GridManager.Instance)
        plant = Instantiate<GameObject>(profabPlant);

    }
    IEnumerator calCD() {
        nowCDTime = CDTime;
        while (nowCDTime >= 0) {
            yield return new WaitForSeconds(0.1f);
            nowCDTime -= 0.1f;
            maskImg.fillAmount = nowCDTime / CDTime;
            //print(nowCDTime);
        }

        maskImg.fillAmount = 0;
        IsPlace = true;
    }

    private void OnMouseDown() {
        createCardPlant();
    }

    private void OnMouseDrag() {
        movePlant();
    }

    private void OnMouseUp() {
        placePlant();
    }

    // Update is called once per frame
    void Update() {
    }

}
