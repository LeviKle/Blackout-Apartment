using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public bool movingHorizontal;
    public bool movingVerticle;
    private bool stagnantTeleport;
    private float timePassed;


    [SerializeField] private AudioSource runSoundEffect;
    [SerializeField] private AudioSource teleportSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
      

    }

    // Update is called once per frame
    void Update()
    {
        if (!stagnantTeleport)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            
        }
        else if(timePassed > 0.8f)
        {
            transform.position = movePoint.position;
            stagnantTeleport = false;
        }
        else
        {
            timePassed += Time.deltaTime;

        }
        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        { //move iff the player position (transform.position) catches movepoint
            
            if (Input.GetKey("a") || Input.GetKey("d"))
            {
                
                int move = 1;
                if (Input.GetKey("a"))
                {
                    move = -1;
                }
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(move, 0f, 0f), 0.2f, whatStopsMovement))
                {
                    runSoundEffect.Play();
                    movingHorizontal = true;
                    movePoint.position += new Vector3(move, 0f, 0f); //moving the Movepoint
                    
                    if (move > 0)
                    { //flipping
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else if (move < 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                } 
                moveSpeed = 2f;
            }
            else if (Input.GetKey("w") || Input.GetKey("s"))
            {
                movingHorizontal = false;
                int move;
                if (Input.GetKey("w"))
                {
                    move = 1;
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, move * 2, 0f), 0.2f, whatStopsMovement))
                    {
                        teleportSoundEffect.Play();
                        movingVerticle= true;
                        stagnantTeleport = true;
                        timePassed = 0;
                        movePoint.position += new Vector3(0f, move * 3, 0f);

                    }

                }
                else if (Input.GetKey("s"))
                {
                    move = -1;

                    //check if there's a block underneath
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, move, 0f), 0.2f, whatStopsMovement))
                    {
                        teleportSoundEffect.Play();
                        movingVerticle = true;
                        stagnantTeleport = true;
                        timePassed = 0;
                        movePoint.position += new Vector3(0f, move * 3, 0f);
                    }
                }
                moveSpeed = 3f;
            } else {
                movingHorizontal = false;
                movingVerticle = false;
            }
        }

    }

    private IEnumerator MoveVertical()
    {
        yield return new WaitForSeconds(0.9f);
        transform.position = movePoint.position;
    }    
}
