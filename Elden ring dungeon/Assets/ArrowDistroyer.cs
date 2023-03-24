using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDistroyer : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Destroy(other.gameObject);
        }
    }
}
