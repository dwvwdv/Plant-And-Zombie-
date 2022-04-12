using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public static Stash Instance;
    public GameConf GameConf { get;private set; }

    private int _sunNum;

    public int sunNum { 
        get => _sunNum;
        set {
            _sunNum = value;
            UIManager.Instance.updateSunNum(_sunNum);
        }
    }

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        //sunNum += 100;
    }
    
}
