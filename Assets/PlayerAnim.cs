using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    
    private Animator anim;


    public Player script;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {



        if (script.moving == true)
        {
            anim.SetTrigger("PlayerWalk");
            
        }
        
        else
        {
            anim.SetTrigger("PlayerIdle");
        }



    }

}
