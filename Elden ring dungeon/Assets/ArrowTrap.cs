using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform target;
    [SerializeField] private Quaternion rotation;
    [SerializeField] private float speed = 10f;
    [SerializeField] private List<Transform> targets;
    [SerializeField] private int index;
    
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;


    private IEnumerator TimeToInstantiate()
    {
        for (int i = 0; i < index + 1; i++)
        {
            GameObject Arrow = Instantiate(arrow, targets[index].position, rotation);
            Arrow.GetComponent<Rigidbody>().AddForce(new Vector3(x, y, z) * speed * Time.deltaTime, ForceMode.Impulse);
            index += 1;
            yield return new WaitForSeconds(0.2f);
        }
        
        index = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(TimeToInstantiate());
        }
    }
}
