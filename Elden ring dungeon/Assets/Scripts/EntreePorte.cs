using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreePorte : MonoBehaviour
{
    [Range(1, 2)] public int numeroEntree;
    public bool goInside;    // Pour si la porte menne � l'int�rieur d'un batiment

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Interactible"))
        {
            // CHANGEMENTS POSITION
            if (numeroEntree == 1)
                GetComponentInParent<Portes>().EnterDoor1(collision.gameObject);

            else
                GetComponentInParent<Portes>().EnterDoor2(collision.gameObject);


            // CHANGEMENTS CAMERA
            if (goInside)
                GetComponentInParent<Portes>().GoInside();

            else
                GetComponentInParent<Portes>().GoOutside();
        }
    }
}
