using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Animator ani;
    private int walkSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponentInChildren<Animator>();
        int randWalk = Random.Range(0,3);
        switch (randWalk) {
            case 0:
                ani.Play("Zombie_Walk1");
                walkSpeed = 3;
                break;
            case 1:
                ani.Play("Zombie_Walk2");
                walkSpeed = 6;
                break;
            case 2:
                ani.Play("Zombie_Walk3");
                walkSpeed = 9;
                break;
        }
        this.transform.position = new Vector3(6.67f, GridManager.Instance.getRandomLine(), 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    void move() {   
        this.transform.position = new Vector3(this.transform.position.x - (walkSpeed*0.002f), transform.position.y, 0);
    }
}
