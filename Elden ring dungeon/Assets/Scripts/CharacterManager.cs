using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterManager : MonoBehaviour
{
    [Header("Scripts")] public CharacterMovement movementScript;

    [Header("Références")]
    [HideInInspector] public Rigidbody rb;

    [Header("Inputs")]
    [HideInInspector] public Vector2 direction;
    [HideInInspector] public bool interaction;

    [Header("Autres")] 
    [HideInInspector] public bool noMovement;
    [HideInInspector] public bool noControl;
    [HideInInspector] public bool isMovingObjects;

    public static CharacterManager instance;

    public void Awake()
    {
        instance = this;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!noControl)
        {
            // Partie déplacement player 
            if (!noMovement && !isMovingObjects)
            {
                movementScript.MoveCharacter(direction);
                
                if(direction == Vector2.zero)
                    movementScript.RotateCharacter();
            }
        }
    }
    
    public void OnDirection(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        interaction = context.performed;
    }
}
