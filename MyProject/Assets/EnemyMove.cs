using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform player;
    
    [SerializeField] Vector3 moveDirection;
    [SerializeField] float moveSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    void Update()
    {
        moveDirection = player.transform.position - transform.position; 
        
        Move();
        
    }

    

    protected virtual void Move()
    {
        transform.Translate(moveDirection * moveSpeed *Time.deltaTime);
    }
}
