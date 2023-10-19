using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerAnim : MonoBehaviour
{

    public bool notMoving;
    private Animator anim;
    

    public Killer script;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
        
       
        if (script.movingHorizontal == true)
        {
            anim.SetTrigger("Walk");
            notMoving = false;
        }
        else if (script.movingVerticle == true)
        {
            //print("going up");
            anim.SetTrigger("GoUp");
            notMoving = false;
        }
        else
        {
            notMoving = true;
        }
        

        
    }
   
}
