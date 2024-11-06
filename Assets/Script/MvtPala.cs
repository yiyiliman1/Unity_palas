using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtPala : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //x = Input.GetAxis("Horizontal");    // atl + flechas para mover el codigo
        y = Input.GetAxis("Vertical"); // control + k + c reorganizar el codigo
        // para comertar todo control + k + c (es necesario seleccionar todo previamente)
        // para descomertar todo control + k + u (es necesario seleccionar todo previamente)
        //if (gameObject.name == "PalaIZ")
        //{
        //    x = Input.GetAxis("Horizontal");     
        //    y = Input.GetAxis("Vertical");     
        //} else if (gameObject.name == "PalaDE") {
        //    x = Input.GetAxis("player (h)");
        //    y = Input.GetAxis("player (v)");
        //}
    }
    private void FixedUpdate()
    {
        // cada vez que quieras modificar el rigibody aqui
        rb.velocity = new Vector2(x, y) * speed; // 2 de 2d
        // ajustas la velocidad en los componentes de unity*
    }

}
