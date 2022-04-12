using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    private Text sunNumText;
    private GameObject[] Card;

    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sunNumText = GameObject.Find("SunTotalText").GetComponent<Text>();
        //for(int i=0;i<6;i++)
            //Card[i] = GameObject.Find("Card" + (i+1)).GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateSunNum(int n) {
        sunNumText.text = n.ToString();
    }

    public Vector3 getSunNumTextPos() {
        return sunNumText.transform.position;
    }
    public GameObject getCard(int index) {
        return Card[index];
    }
}
