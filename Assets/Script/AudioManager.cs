using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton para acceso global al AudioManager
    private List<GameObject> activeAudios; // Lista que almacena objetos de audio activos (no en loop)


    private void Awake()
    {
        if (!instance) // Verifica si ya existe una instancia
        {
            instance = this; // Asigna esta como la instancia única
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cargar nuevas escenas
            activeAudios = new List<GameObject>(); // Inicializa la lista de objetos activos
        }
        else
        {
            Destroy(gameObject); // Destruye duplicados del AudioManager
        }
    }

    public AudioSource PlayAudio(AudioClip clip, string objectName, float volume = 1, bool isLoop = false)
    {
        // Crea un nuevo GameObject para el audio
        GameObject audioObject = new GameObject(objectName);
        // Agrega un componente AudioSource al objeto
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();
        // Configura las propiedades del AudioSource
        audioSourceComponent.clip = clip;
        audioSourceComponent.volume = volume;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();

        // Si no es un audio en loop, agrega el objeto a la lista de activos y verifica su estado
        if (isLoop)
        {
            activeAudios.Add(audioObject);
            StartCoroutine(CheckAudio(audioSourceComponent)); // Comienza la corrutina
        }

        audioSourceComponent.Play(); // Reproduce el audio

        return audioSourceComponent; // Devuelve la referencia al AudioSource
    }

    IEnumerator CheckAudio(AudioSource audioSource)
    {
        // Mientras el audio esté reproduciéndose
        while (audioSource.isPlaying)
        {
            yield return new WaitForSeconds(.2f); // Espera 0.2 segundos antes de volver a verificar
        }
        // Cuando el audio termina, remueve el objeto de la lista y destrúyelo
        activeAudios.Remove(audioSource.gameObject);
        Destroy(audioSource.gameObject);
    }
}

