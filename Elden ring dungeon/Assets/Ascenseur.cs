using System;
using Unity.VisualScripting;
using UnityEngine;

public class Ascenseur : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private float speed;
    [SerializeField] private float speedForPortail;
    
    [SerializeField] private Transform targetTop;
    [SerializeField] private Transform targetDown;
    [SerializeField] private Transform targetPortailTop;
    [SerializeField] private Transform targetPortailDown;
    
    [SerializeField] private bool isMoving;
    [SerializeField] private bool isOnBoard;
    [SerializeField] private bool isOnTop;

    [SerializeField] private GameObject ponts;
    [SerializeField] private GameObject portail;
    [SerializeField] private GameObject porteFermée;

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
                ponts.SetActive(false);
                target = targetDown;
                Descente();
            }
            else
            {
                ponts.SetActive(true);
                porteFermée.SetActive(false);
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
            canvas.SetActive(true);
            isOnBoard = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
            canvas.SetActive(false);
            isOnBoard = false;
        }
    }

    private void Ascension()
    {
        transform.position = Vector3.Lerp(transform.position, targetTop.position, speed * Time.deltaTime);
        portail.transform.position = Vector3.Lerp(transform.position, targetPortailDown.position, speed * Time.deltaTime);
    }

    private void Descente()
    {
        transform.position = Vector3.Lerp(transform.position, targetDown.position, speedForPortail * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPortailTop.position, speedForPortail * Time.deltaTime);
    }
}
