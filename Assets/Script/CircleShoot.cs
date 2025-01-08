using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Camera _cam;
    public int numberOfBullet = 12;
    public GameObjectPull bulletPool;

    void Start()
    {
        _cam = Camera.main; // para encontrar la camara    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenCoords = Input.mousePosition;
            Vector3 gameCoords = _cam.ScreenToWorldPoint(screenCoords);
            gameCoords.z = 0;

            float step = 360f/numberOfBullet;

            for (int i = 0; i < numberOfBullet; i++)
            {
                float angle = step * i;
                Vector2 direction = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad),
                    Mathf.Cos(angle * Mathf.Deg2Rad));

                GameObject o = bulletPool.GetAvailableObject();  
                o.transform.position = gameCoords;
                o.SetActive(true);  
                o.GetComponent<Bullet>().SetDirection(direction);
            }

            Instantiate(bulletPrefab, gameCoords, Quaternion.identity);
        }
    }
}
