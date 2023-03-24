using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("References")] 
    private CharacterManager manager;

    [Header("Movements")]
    [SerializeField, Range(0f, 100f)] float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)] float maxAcceleration = 10f;
    private Vector3 velocity;
    private void Awake()
    {
        manager = GetComponent<CharacterManager>();
    }


    //------------------------------------------------------------------------------------------------------------------
    

    // BOUGE LE PERSONNAGE
    public void MoveCharacter(Vector2 direction)
    {
        Vector3 desiredVelocity = new Vector3(direction.x, 0f, direction.y) * maxSpeed;
        
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        
        // Acceleration du personnage
        velocity = transform.InverseTransformDirection(manager.rb.velocity);
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        manager.rb.velocity = transform.TransformDirection(velocity);
    }

    // ORIENTATION DU PERSONNAGE EN FONCTION DE L'ANGLE DE CAMERA
    public void RotateCharacter()
    {
        transform.rotation = Quaternion.Euler(0, ReferenceManager.Instance.cameraReference.transform.rotation.eulerAngles.y, 0);
    }
}
