using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip clip;
    [Range(0, 1)] // sale en interfaz de unity
    public float volume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudio(clip, "Musica fondo", volume, true);
    }
}
