using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGosling : MonoBehaviour
{
    [SerializeField] private string gunTag = "gun";
    [SerializeField] private InputAction abilityPlayer;
    [SerializeField] private AudioClip gunShootClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timer = 3f;
    [SerializeField] private Transform bulletPrefab;


    private bool _isArmed = false;
    private bool _isLoaded = true;

    private void Start()
    {
        StartCoroutine(RepeatedFunction());
    }

    IEnumerator RepeatedFunction()
    {
        while (true) // Бесконечный цикл для повторяющегося выполнения
        {
            // Ваш код, который должен выполняться каждые 3 секунды, здесь
            _isLoaded = true;

            // Ждем 3 секунды
            yield return new WaitForSeconds(timer);
        }
    }

    private void TakeGun(Collider2D collision)
    {
        if(collision.tag == gunTag)
        {
            collision.gameObject.SetActive(false);
            _isArmed |= true;
            transform.GetChild(transform.childCount - 2).gameObject.SetActive(true);
            transform.GetChild(transform.childCount - 3).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeGun(collision);
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
        if (context.performed && _isArmed && _isLoaded)
        {
            audioSource.PlayOneShot(gunShootClip);
            _isLoaded = false;
            Instantiate(bulletPrefab, transform.GetChild(transform.childCount - 1).position, Quaternion.identity);     
        }
    }
}
