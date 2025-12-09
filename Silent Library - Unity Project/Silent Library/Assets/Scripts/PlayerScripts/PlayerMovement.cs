using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public GameObject playerModel;

    public  InputAction move;
    public  InputAction rotateLeft;
    public  InputAction rotateRight;

    public float moveSpeed = 5f;
    public bool isMoving;

    void Start()
    {
        isMoving = false;
        move = InputSystem.actions.FindAction("Player/Move");
        rotateLeft = InputSystem.actions.FindAction("Player/RotateLeft");
        rotateRight = InputSystem.actions.FindAction("Player/RotateRight");
    }

    void Update()
    {
        PlayerMove();
        PlayerRotate();
    }

    public void PlayerMove()
    {
        Vector2 moveValue = move.ReadValue<Vector2>();

        if (moveValue != Vector2.zero)
        {
            Vector2 moveDirection = new Vector2(moveValue.x, moveValue.y);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
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
