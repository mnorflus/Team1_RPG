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
        
        if(other.CompareTag("enemy"))
        {
            
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
                //Debug.Log("Object name: " + other.gameObject.name);
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Debug.Log("difference: " + difference);
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            Debug.Log("velocity: " + enemy.velocity);
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
            //Debug.Log("velocity: " + enemy.velocity);
        }
    }

}
