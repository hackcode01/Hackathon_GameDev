using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // ������ �� ��������� AudioSource
    public AudioClip soundClip; // ������ �� ���������

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���������� ���� ��� ������� ������� "������"
            audioSource.PlayOneShot(soundClip);
        }
    }
}
