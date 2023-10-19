using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnim : MonoBehaviour
{
    public KillerAnim script;

    private Animator anim;

    private float timeBtwAttack = 3.1f;
   

    public Transform attackPos;
    public float attackRange;
    public LayerMask playerHitbox;
    public int damage;
    [SerializeField] private AudioSource slashing;

   

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (script.notMoving == true) {
            
            if (Input.GetKey("g") && timeBtwAttack > 2)
            {
                slashing.Play();
                anim.SetTrigger("Attack");
                //reset timeBtwkAttack
                timeBtwAttack = 0;


                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerHitbox);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Player>().TakeDamage(damage);
                }

            }

            else
            {

                timeBtwAttack += Time.deltaTime;
            }

            
                anim.SetTrigger("GoIdle");
            

            
        }


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
