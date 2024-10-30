using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if (ball)
        {
            ball.ResetPosition();
            
        }
    }
}
