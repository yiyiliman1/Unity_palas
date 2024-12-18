using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvtPala : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float x, y;
    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _cam = Camera.main; // para solucionar el problemas de las palas en el movil, creamos camara
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE || UNITYEDITOR // para que use un control u otro dependiendo de que sistema estes
        //control pc
        //x = Input.GetAxis("Horizontal");    // atl + flechas para mover el codigo
        y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(0, y) * speed * Time.deltaTime);// control + k + c reorganizar el codigo
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
#elif UNITY_ANDROID || UNITY_IOS

        // movimiento de movil
        foreach (Touch touch in Input.touches)
        {
            // hay cuatro fases de touch
            Vector2 screenCoords = touch.position;
            Vector3 worldCoords = _cam.ScreenToWorldPoint(screenCoords);


            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x, worldCoords.y, transform.position.z);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            }
        } 
#endif
    }
    private void FixedUpdate()
    {
        // cada vez que quieras modificar el rigibody aqui
        //rb.velocity = new Vector2(x, y) * speed; // 2 de 2d
        // ajustas la velocidad en los componentes de unity

     
    }

}

