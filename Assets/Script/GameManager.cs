using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[] puntuacion;
    // patronn de diseño singleton
    // es una variable que solo puede existir un sola variable y es accesible desde cualquier parte
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake() // antes del start
    {
        if (!instance)
        {
            // tenemos que establecer un nuevo gameManagaer
            instance = this; // hace referencia al new gameManager que nos escontramos
            // cada vez que cambiamos de escena se destruye todo, inlcuido el gameManager
            DontDestroyOnLoad(gameObject);  
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        puntuacion = new int[2];    
    }
    public int GetIndexPuntuacion(int index)
    {
        return puntuacion[index];
    }
    public void SetIndexPuntuacion(int index, int nValue) // para que entre el nuevo valor
    {
        puntuacion[index] = nValue;    
    }

}