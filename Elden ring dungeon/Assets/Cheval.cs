using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheval : MonoBehaviour
{
    [SerializeField] Transform[] targets;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int index;

    private void Start()
    {
        StartCoroutine(Chemin(targets[index]));
    }
    
    private IEnumerator Chemin(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);

            yield return null;
        }

        if (index + 1 < targets.Length)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        StartCoroutine(Chemin(targets[index]));
    }
}
