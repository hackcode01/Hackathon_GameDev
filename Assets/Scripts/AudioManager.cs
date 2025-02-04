using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на компонент AudioSource
    public AudioClip soundClip; // Ссылка на аудиофайл

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Проиграйте звук при нажатии клавиши "Пробел"
            audioSource.PlayOneShot(soundClip);
        }
    }
}
