using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _target;
    private Vector3 _velocity = Vector3.zero;

    [Range(0, 1)]
    [SerializeField] private float smoothTime;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 positionOffset = new(0, 0, -10);
        Vector3 targetPosition = _target.position + positionOffset;
        transform.position = Vector3.SmoothDamp(transform.position,
            targetPosition, ref _velocity, smoothTime);
    }
}
