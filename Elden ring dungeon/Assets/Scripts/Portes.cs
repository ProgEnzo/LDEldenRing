using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portes : MonoBehaviour
{
    [SerializeField] Transform charaPos1;
    [SerializeField] Transform charaPos2;

    [SerializeField] Transform cameraPos1;
    [SerializeField] Transform cameraPos2;

    [Header("Limites Camera")]
    [SerializeField] Transform minXZ;
    [SerializeField] Transform maxXZ;


    public void EnterDoor1(GameObject movedObject)
    {
        movedObject.transform.position = charaPos2.position;

        ReferenceManager.Instance.cameraReference.transform.position = cameraPos2.position;
        ReferenceManager.Instance.cameraReference.transform.rotation = cameraPos2.rotation;
    }

    public void EnterDoor2(GameObject movedObject)
    {
        movedObject.transform.position = charaPos1.position;

        ReferenceManager.Instance.cameraReference.transform.position = cameraPos1.position;
        ReferenceManager.Instance.cameraReference.transform.rotation = cameraPos1.rotation;
    }

    public void GoInside()
    {
        ReferenceManager.Instance.cameraReference.GetComponent<CameraMovement>().EnterRoom(minXZ.position, maxXZ.position);
    }

    public void GoOutside()
    {
        ReferenceManager.Instance.cameraReference.GetComponent<CameraMovement>().ExitRoom();
    }
}
