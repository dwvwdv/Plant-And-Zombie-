using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIPlantCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler ,IPointerClickHandler{
    private Image maskImg;
    
    private GameObject plant;

    public float CDTime = 3;
    public float nowCDTime;

    private bool wantPlace = false;

    public bool WantPlace {
        get => wantPlace;
        set {
            wantPlace = value;
            if (wantPlace) {
                createCardPlant();
            }
            else
                placePlant();
        }
    }

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
        if (plant == null) return;
        plant.transform.position = GridManager.Instance.getGridPointByMouse();
        plant.GetComponent<SunFlower>().init();
        IsPlace = false;
    }

    void movePlant() {
        Vector2 v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        plant.transform.position = v2;
    }

    void createCardPlant() {
        if (!IsPlace)
            return;
        GameObject prefab = PlantManager.Instance.getPlantForType(PlantType.SunFlower);
        plant = Instantiate(prefab);
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

    

    

    // Update is called once per frame
    void Update() {
        if (wantPlace && plant != null) {
            movePlant();
            if (Input.GetMouseButtonDown(0))
                WantPlace = false;
            else if(Input.GetMouseButtonDown(1)) {
                Destroy(plant);
                plant = null;
                WantPlace = false;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (nowCDTime > 0)
            return;
        print("click");
        if (!WantPlace)
            WantPlace = true;
    }
}
