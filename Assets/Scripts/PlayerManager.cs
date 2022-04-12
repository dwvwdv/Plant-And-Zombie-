using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private void Awake() {
        Instance = this;
    }

    private int _sunNum;
    public int sunNum {
        get => _sunNum;
        set {
            _sunNum = value;
            UIManager.Instance.updateSunNum(_sunNum);
        }
    }
}
