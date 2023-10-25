using UnityEngine;

public class AstronautPlayer : MonoBehaviour, IUnit
{
    private Animator anim;
    private CharacterController controller;

    public float moveSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;

    public FloatingJoystick joystick;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        if (controller.isGrounded)
        {
            float horizontalMovement = horizontalInput * moveSpeed;
            float verticalMovement = verticalInput * moveSpeed;

            moveDirection = new Vector3(horizontalMovement, 0, verticalMovement);

            if (moveDirection != Vector3.zero)
            {
                // Oblicz kierunek ruchu na podstawie wartoœci wejœcia z joysticka
                Vector3 lookDirection = new Vector3(horizontalInput, 0, verticalInput);
                if (lookDirection != Vector3.zero)
                {
                    // Obróæ gracza w kierunku ruchu
                    transform.rotation = Quaternion.LookRotation(lookDirection);
                }
                controller.Move(moveDirection * Time.deltaTime);

                anim.SetInteger("AnimationPar", 1); // Uruchom animacjê ruchu
            }
            else
            {
                anim.SetInteger("AnimationPar", 0); // Wy³¹cz animacjê, jeœli nie ma ruchu
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IFarmUnit farm))
        {
            farm.Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IFarmUnit farm))
        {
            farm.ExitInteractField();
        }
    }
}
