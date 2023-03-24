using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   private Camera _camera;
    
    [Header("CameraRoom")]
    private bool isStatic;
    [HideInInspector] public Vector3 minXYZ;
    [HideInInspector] public Vector3 maxXYZ;
    private Vector3 offset;

    [Header("DebutStatic")] 
    [SerializeField] private bool startMove;       // Si on veut que la camera bouge d�s le d�part
    public Transform startMinXZ;
    public Transform startMaxXZ;

    [Header("Autres")]
    private Vector3 savePosition;     // Lorsque qu'on déplace un objet et qu'on change de camera avec, cette variable permet de retourner à la camera originelle
    private Quaternion saveRotation;     


    private void Start()
    {
        _camera = GetComponent<Camera>();

        if (startMove)
        {
            isStatic = false;

            minXYZ = startMinXZ.position;
            maxXYZ = startMaxXZ.position;
        }

        else
        {
            isStatic = true;
        }
    }


    private void Update()
    {
        if (!isStatic)
        {
            Vector3 charaPos = ReferenceManager.Instance.characterReference.transform.position;

            MoveCamera(charaPos);
        }
    }



    // PERMET DE DEPLACER LA CAMERA TOUT EN NE SORTANT DE CERTAINES LIMITES EN X ET EN Z
    private void MoveCamera(Vector3 wantedPos)
    {
        Vector3 newPos = new Vector3(0, 0, 0);

        // On determine la position en X
        if(wantedPos.x < minXYZ.x)
        {
            newPos.x = minXYZ.x;
        }
        else if(wantedPos.x > maxXYZ.x)
        {
            newPos.x = maxXYZ.x;
        }
        else
        {
            newPos.x = ReferenceManager.Instance.characterReference.transform.position.x;
        }

        // On determine la position en Z
        if (wantedPos.z < minXYZ.z)
        {
            newPos.z = minXYZ.z;
        }
        else if (wantedPos.z > maxXYZ.z)
        {
            newPos.z = maxXYZ.z;
        }
        else
        {
            newPos.z = ReferenceManager.Instance.characterReference.transform.position.z;
        }
        
        //On determine la position en Y
        if (wantedPos.y < minXYZ.y)
        {
            newPos.y = minXYZ.y;
        }
        else if (wantedPos.y > maxXYZ.y)
        {
            newPos.y = maxXYZ.y;
        }
        else
        {
            newPos.y = ReferenceManager.Instance.characterReference.transform.position.y; 
        }

        // Application des changements
        transform.position = new Vector3(newPos.x + offset.x, newPos.y + offset.y, newPos.z + offset.z);
    }


    // QUAND ON ENTRE DANS UNE PIECE
    public void EnterRoom(Vector3 newMinXYZ, Vector3 newMaxXYZ)
    {
        offset = transform.position - ReferenceManager.Instance.characterReference.transform.position;
        isStatic = false;

        minXYZ = newMinXYZ;
        maxXYZ = newMaxXYZ;
    }

    // QUAND ON QUITTE UNE PIECE
    public void ExitRoom()
    {
        isStatic = true;
    }
}
