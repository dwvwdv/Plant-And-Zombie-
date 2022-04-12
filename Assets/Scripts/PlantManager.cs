using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType {
    SunFlower,
}

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;
    private void Awake() {
        Instance = this;
    }

    //void Lock<T>(T cardPlant) {
    //    cardPlant
    //}

    public GameObject getPlantForType(PlantType type) {
        switch (type) {
            case PlantType.SunFlower:
                return Stash.Instance.GameConf.sunFlower;

            default:
                return null;
        }
    }
}
