using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public static GridManager Instance;

    private void Awake() {
        Instance = this;
    }

    //[SerializeField]
    //private List<Vector2> pointList = new List<Vector2>();
    private List<Grid> gridList = new List<Grid>();
    private void Start() {
        //createGridBaseColl();
        createGridsBaseColl();
    }

    private void Update() {
        //if(Input.GetMouseButtonUp(0))
            //print(getGridPointByMouse());
    }

    private void createGridBaseColl() {

        GameObject prefabGrid = new GameObject();
        prefabGrid.AddComponent<BoxCollider2D>().size = new Vector2(1, 1.5f);
        prefabGrid.transform.SetParent(this.transform);
        prefabGrid.transform.position = this.transform.position;
        prefabGrid.name = 0 + "-" + 0;

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 9; j++) {
                GameObject grid = GameObject.Instantiate<GameObject>(prefabGrid, this.transform.position + new Vector3(j * 1.33f, i * 1.63f, 0), Quaternion.identity, this.transform);
                grid.name = i + "-" + j;
            }
        }
    }

    private void createGridsBaseColl() {

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 9; j++) {
                //pointList.Add(this.transform.position + new Vector3(j * 1.33f, i * 1.63f,0));
                gridList.Add(new Grid(new Vector2(i, j), this.transform.position + new Vector3(j * 1.33f, i * 1.63f, 0), true));
            }
        }
    }

    public Vector2 getGridPointByMouse() {
        float dis = 1000000;
        Vector2 point = gridList[0].position;
        for(int i = 0; i < gridList.Count; i++) {
            float t = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), gridList[i].position);
            if (t < dis) {
                dis = t;
                point = gridList[i].position;
            }
        }

        return point;
    }
}