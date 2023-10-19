using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.7f;

    public GameOverScreenKiller script;

    private float timeFromDeath;
    public Transform movePoint;
    public int health;
    public bool moving;
    [SerializeField] private AudioSource walking;


    public LayerMask whatStopsMovement;


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            if (timeFromDeath > 1.5)
            {


                script.Setup();
            }
            else
            {
                timeFromDeath += 1 * Time.deltaTime;

            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);


            if (Vector3.Distance(transform.position, movePoint.position) == 0f)
            { //move iff the player position (transform.position) catches movepoint
                if (Input.GetKey("right") || Input.GetKey("left"))
                {

                    int move = 1;
                    if (Input.GetKey("left"))
                    {
                        move = -1;
                    }
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(move, 0f, 0f), 0.2f, whatStopsMovement))
                    {
                        walking.Play();
                        moving = true;
                        movePoint.position += new Vector3(move, 0f, 0f); //moving the Movepoint
                        if (move > 0)
                        { //flipping
                            transform.localScale = new Vector3(1, 1, 1);
                        }
                        else if (move < 0)
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                        }
                    }
                    moveSpeed = 1.7f;
                }
                else if (Input.GetKey("up") || Input.GetKey("down"))
                {

                    int move;
                    if (Input.GetKey("up"))
                    {

                        move = 1;
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, move * 2, 0f), 0.2f, whatStopsMovement))
                        {
                            walking.Play();
                            moving = true;
                            movePoint.position += new Vector3(0f, move * 3, 0f);
                        }

                    }
                    else if (Input.GetKey("down"))
                    {
                        walking.Play();
                        move = -1;
                        moving = true;
                        //check if there's a block underneath
                        if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, move, 0f), 0.2f, whatStopsMovement))
                        {
                            movePoint.position += new Vector3(0f, move * 3, 0f);
                        }
                    }
                    moveSpeed = 3f;
                }
                else
                {
                    moving = false;
                }
            }
        }

        
        

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
