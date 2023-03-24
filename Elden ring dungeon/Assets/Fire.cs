using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FireTimer());
        }
    }

    private IEnumerator FireTimer()
    {
        for (int i = 0; i < 100; i++)
        {
            fire.SetActive(true);
            yield return new WaitForSeconds(timer);
            fire.SetActive(false);
            yield return new WaitForSeconds(timer);
            fire.SetActive(true);
            yield return new WaitForSeconds(timer);
        }
    }
}
