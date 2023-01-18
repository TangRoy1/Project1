using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopMobs : MonoBehaviour
{
    private Rigidbody2D physic;

    public Transform hero;

    public float speed;
    public float agroDistance;

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, hero.position);

        if (distToPlayer < agroDistance)
        {
            StartHunting();
        }
        else 
        {
            StopHunting();
        }
    }

    void StartHunting() 
    {
        if(hero.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(3, 3);
        }
        else if (hero.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-3, 3);
        }
    }
    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }
}
