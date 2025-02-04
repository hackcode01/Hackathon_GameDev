using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnerBarrel : MonoBehaviour
{
    [SerializeField] private Transform prefabBarrel; 
    [SerializeField] private float timer = 3f; 

    private void Start()
    {
        StartCoroutine(RepeatedFunction());
    }

    IEnumerator RepeatedFunction()
    {
        while (true) // ����������� ���� ��� �������������� ����������
        {
            // ��� ���, ������� ������ ����������� ������ 3 �������, �����
            Instantiate(prefabBarrel, transform.position, Quaternion.identity);


            // ���� 3 �������
            yield return new WaitForSeconds(timer);
        }
    }
}
