using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust; // force of knockback, can be used for adjusting knockback
    public float knockTime;

    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<pot>().Smash();
        }
        if(other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>(); // object being hit
            if(hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Debug.Log("difference: " + difference);
                hit.AddForce(difference, ForceMode2D.Impulse);
                if(other.gameObject.CompareTag("enemy"))
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }
                if(other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerMovement>().Knock(knockTime);
                }
                
                //Debug.Log("Object name: " + other.gameObject.name);
                
                //StartCoroutine(KnockCo(hit));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            //Debug.Log("velocity: " + enemy.velocity);
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
            //Debug.Log("velocity: " + enemy.velocity);
        }
    }

}
