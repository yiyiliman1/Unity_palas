using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public AudioClip bounceAudioClip;
    private Rigidbody2D rb;
    private Vector2 direccion;
    private Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // accede a la lista de compomnente al cual este componente este asignado

        do
        {
            direccion.x = Random.Range(-1, 2); // no incluye el primero, por eso ponemos 2
        } while (direccion.x == 0);
        direccion.y = Random.Range(-1, 2);
        initialPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
        speed = 5;
    }

    private void FixedUpdate()
    {

        rb.velocity = direccion * speed; // la pelota va hacia la derecha
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlayAudio(bounceAudioClip, "Boing Sound Effect", 0.3f);
        // cada vez que choca la pelota, rebota. Se choca collision
        if (collision.gameObject.GetComponent<MvtPala>())
        {
            direccion.x *= -1; // direccion.x = direccion.x * -1
            direccion.y = Random.Range(-1, 2);
        }
         else // cada ves que ocurra una colision con cualquier cosa
        {
            // solo hay techo o suelo
            direccion.y *= -1;
            speed += 1;


        }
        
    }
    
}
