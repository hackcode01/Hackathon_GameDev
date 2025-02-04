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
        while (true) // Бесконечный цикл для повторяющегося выполнения
        {
            // Ваш код, который должен выполняться каждые 3 секунды, здесь
            Instantiate(prefabBarrel, transform.position, Quaternion.identity);


            // Ждем 3 секунды
            yield return new WaitForSeconds(timer);
        }
    }
}
