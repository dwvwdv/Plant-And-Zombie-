using UnityEngine;


[CreateAssetMenu(fileName ="config",menuName ="GameConf")]

public class GameConf : ScriptableObject{
    [Tooltip("陽光預製體")]
    public GameObject sun;
    [Tooltip("太陽花")]
    public GameObject sunFlower;
    [Tooltip("豌豆射手")]
    public GameObject peashooter;
}
