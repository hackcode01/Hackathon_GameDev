using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOpengamer : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private string _uraniumTag = "uranium";
    [SerializeField] private InputAction abilityPlayer;
    [SerializeField] private AudioSource audioSours;
    [SerializeField] private int uraniumNeed = 3;
    [SerializeField] private AudioClip boomClip;
    [SerializeField] private GameObject boomObject;

    static private int _uraniumCounter = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ColectingUranium(other);
    }

    private void ColectingUranium(Collider2D other)
    {
        if (other.CompareTag(_uraniumTag))
        {
            other.gameObject.SetActive(false);
            _uraniumCounter++;
        }
    }

    static public int GetUraniumCounter()
    {
        return _uraniumCounter;
    }

    private void OnEnable()
    {
        abilityPlayer.Enable();
        abilityPlayer.performed += InteractPerformed;
    }

    private void OnDisable()
    {
        abilityPlayer.Disable();
        abilityPlayer.performed -= InteractPerformed;
    }

    private void InteractPerformed(InputAction.CallbackContext context)
    {
        // Этот метод будет вызван при нажатии кнопки "E"
        if (context.performed)
        {
            if (PlayerOpengamer.GetUraniumCounter() >= uraniumNeed)
            {
                player.Win();
                audioSours.PlayOneShot(boomClip);
                boomObject.SetActive(true);
            }
        }
    }
}
