using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public static Stash Instance;
    public GameConf GameConf { get;private set; }

    private void Awake() {
        Instance = this;
        GameConf = Resources.Load<GameConf>("config");
    }
    
}
