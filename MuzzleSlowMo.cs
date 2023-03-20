using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleSlowMo : MonoBehaviour
{
    private MovementController checkForSlowMotion;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        checkForSlowMotion = GameObject.Find("Player").GetComponent<MovementController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkForSlowMotion.slowDown == true)
        {
            anim.speed = 0.3f;
        }
        else if (checkForSlowMotion.slowDown == false)
        {
            anim.speed = 1f;
        }
    }
}
