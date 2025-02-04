using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private string barrelTag = "barrel"; 
    [SerializeField] private string playerTag = "player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(barrelTag))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag(playerTag)) 
        {
            player.Dead();
        }
    }
}
