using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyP : MonoBehaviour
{
    public float moveSpeed;
    public float range;
    public float StartingY ;
    private int direction=1;

    // Start is called before the first frame update
    void Start()
    {
        StartingY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     transform.Translate(Vector2.up * (moveSpeed * Time.deltaTime * direction));
     if (transform.position.y < StartingY || transform.position.y >StartingY+range)
     {
         direction *= -1;
     }
    }
}

