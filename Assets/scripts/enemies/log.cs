using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Enemy
{
    private Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if((currentState == EnemyState.idle || currentState == EnemyState.walk)
            && currentState != EnemyState.stagger
            && Vector3.Distance(target.position, 
                            transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime); // move speed per second
            myRigidBody.MovePosition(temp);
            ChangeState(EnemyState.walk);
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState) 
            currentState = newState;
    }
}
