using UnityEngine;


[CreateAssetMenu(fileName ="config",menuName ="GameConf")]

public class GameConf : ScriptableObject{
    [Tooltip("�����w�s��")]
    public GameObject sun;
    [Tooltip("�Ӷ���")]
    public GameObject sunFlower;
    [Tooltip("�ܨ��g��")]
    public GameObject peashooter;
}
