using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform targetTop;
    [SerializeField] private Transform targetDown;
    
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isOnBoard;
    [SerializeField] private bool isOnTop;

    [SerializeField] private GameObject levier;
    [SerializeField] private GameObject ascenseur;
    
    private CharacterManager chara;
    
    private void Start()
    {
        chara = CharacterManager.instance;
    }

    private void Update()
    {
        if (!isOnBoard)
            return;
        
        if (!isMoving)
        {
            if (chara.interaction)
            {
                isMoving = true;
            }
        }
        else
        {
            Transform target;
                
            if (isOnTop)
            {
                target = targetDown;
                Descente();
            }
            else
            {
                target = targetTop;
                Ascension();
            }

            if ((target.position - transform.position).magnitude <= 0.5f)
            {
                isMoving = false;
                isOnTop = !isOnTop;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
            isOnBoard = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
            isOnBoard = false;
        }
    }

    private void Ascension()
    {
        levier.SetActive(true);
        ascenseur.transform.position = Vector3.Lerp(ascenseur.transform.position, targetTop.position, speed * Time.deltaTime);
    }

    private void Descente()
    {
        levier.SetActive(false);
        ascenseur.transform.position = Vector3.Lerp(ascenseur.transform.position, targetDown.position, speed * Time.deltaTime);
    }
}
