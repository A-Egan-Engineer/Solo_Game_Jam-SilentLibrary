using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public GameObject playerModel;

    InputAction move;
    InputAction rotateLeft;
    InputAction rotateRight;

    public float moveSpeed = 5f;

    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rotateLeft = InputSystem.actions.FindAction("Player/RotateLeft");
        rotateRight = InputSystem.actions.FindAction("Player/RotateRight");
    }

    void Update()
    {
        Vector2 moveValue = move.ReadValue<Vector2>();

        if (moveValue != Vector2.zero)
        {
            Vector2 moveDirection = new Vector2(moveValue.x, moveValue.y);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }

        PlayerRotate();
    }

    public void PlayerRotate()
    {
        

        if (rotateLeft.IsPressed())
        {
            var rotatePlayerLeft = playerModel.transform.eulerAngles = new Vector3(0, -180, 0);
            rotatePlayerLeft.Normalize();
        }
        else if (rotateRight.IsPressed())
        {
            var rotatePlayerRight = playerModel.transform.eulerAngles = new Vector3(0, 0, 0);
            rotatePlayerRight.Normalize();
        }
    }

}
