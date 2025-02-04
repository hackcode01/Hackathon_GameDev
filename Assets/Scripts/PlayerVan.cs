using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVan : MonoBehaviour
{
    [SerializeField] private string whipTag = "whip";
    [SerializeField] private InputAction abilityPlayer;
    [SerializeField] private AudioClip whipShootClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timer = 3f;

    private bool _isArmed = false;
    private bool _isLoaded = true;

    private void Start()
    {
        
        StartCoroutine(RepeatedFunction());
    }

    IEnumerator RepeatedFunction()
    {
        while (true) // ����������� ���� ��� �������������� ����������
        {
            // ��� ���, ������� ������ ����������� ������ 3 �������, �����
            _isLoaded = true;

            // ���� 3 �������
            yield return new WaitForSeconds(timer);
        }
    }

    private void TakeWhip(Collider2D collision)
    {
        if (collision.tag == whipTag)
        {
            collision.gameObject.SetActive(false);
            _isArmed |= true;
            transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
            transform.GetChild(transform.childCount - 2).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeWhip(collision);
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
        // ���� ����� ����� ������ ��� ������� ������ "E"
        if (context.performed && _isArmed && _isLoaded)
        {
            audioSource.PlayOneShot(whipShootClip);
            Debug.Log("����");
            _isLoaded = false;
        }
    }
}
