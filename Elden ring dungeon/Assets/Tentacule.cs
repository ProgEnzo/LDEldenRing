using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacule : MonoBehaviour
{
    [SerializeField] private GameObject tente;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tente.SetActive(true);
        }
    }
}
