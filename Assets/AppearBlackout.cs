using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearBlackout : MonoBehaviour
{
    private Renderer spRend;
    public Timer script;
    // Start is called before the first frame update
    
    private void Start(){
        spRend = GetComponent<Renderer>();
        spRend.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
            
        if ((script.timer % 22 >= 13) && (script.timer % 22 <= 17) ){
            
            spRend.enabled = true;
        
        } else {
            spRend.enabled = false;
        }
    }
}
