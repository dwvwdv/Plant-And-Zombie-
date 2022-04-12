using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="config",menuName ="GameConf")]

public class GameConf : ScriptableObject{
    [Tooltip("陽光預製體")]
    public GameObject sun;
}
