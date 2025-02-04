using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("barrel"))
        {
            transform.position = _startPosition;
        }
    }
}
