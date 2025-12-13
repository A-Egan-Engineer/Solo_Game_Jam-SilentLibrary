using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public GameObject playerModel;

    public  InputAction move;
    public InputAction rotateUp;
    public  InputAction rotateDown;
    public  InputAction rotateLeft;
    public  InputAction rotateRight;

    public float moveSpeed = 2f;

    public bool isMoving;
    public bool isFacingUp;
    public bool isFacingDown;
    public bool isFacingLeft;
    public bool isFacingRight;

    void Start()
    {
        isMoving = false;
        isFacingUp = false;
        isFacingDown = false;
        isFacingRight = true;
        isFacingLeft = false;
        move = InputSystem.actions.FindAction("Player/Move");
        rotateLeft = InputSystem.actions.FindAction("Player/RotateLeft");
        rotateRight = InputSystem.actions.FindAction("Player/RotateRight");
        rotateUp = InputSystem.actions.FindAction("Player/RotateUp");
        rotateDown = InputSystem.actions.FindAction("Player/RotateDown");
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
        if (!isMoving)
        {
            playerModel.transform.eulerAngles = new Vector3(0, 0, 0);
            isFacingRight = true;
            isFacingLeft = false;
            isFacingUp = false;
            isFacingDown = false;
        }
        if (rotateLeft.IsPressed())
        {
            var rotatePlayerLeft = playerModel.transform.eulerAngles = new Vector3(0, 180, 0); // A
            rotatePlayerLeft.Normalize();
            isFacingLeft = true;
            isFacingRight = false;
        }
        if (rotateRight.IsPressed())
        {
            var rotatePlayerRight = playerModel.transform.eulerAngles = new Vector3(0, 0, 0); // D
            rotatePlayerRight.Normalize();
            isFacingRight = true;
            isFacingLeft = false;            
        }
        if (isFacingRight && rotateUp.IsPressed())
        {
            var rotatePlayerUp = playerModel.transform.eulerAngles = new Vector3(0, 55, 0); // Facing Right & W
            rotatePlayerUp.Normalize();
            isFacingUp = true;
            isFacingRight = true;
            isFacingLeft = false;
            isFacingDown = false;
        }
        if (isFacingRight && rotateUp.IsPressed() && rotateRight.IsPressed()) // Facing Right & W + D
        {
            var rotatePlayerUp = playerModel.transform.eulerAngles = new Vector3(0, 45, 0);
            rotatePlayerUp.Normalize();
            isFacingUp = true;
            isFacingRight = true;
            isFacingLeft = false;
            isFacingDown = false;
        }
        if (isFacingRight && rotateDown.IsPressed()) // Facing Right & S
        {
            var rotatePlayerDown = playerModel.transform.eulerAngles = new Vector3(0, 60, 0);
            rotatePlayerDown.Normalize();
            isFacingDown = true;
            isFacingRight = true;
            isFacingLeft = false;
            isFacingUp = false;
        }
        if (isFacingRight && rotateDown.IsPressed() && rotateRight.IsPressed()) // Facing Right & S + D
        {
            var rotatePlayerDown = playerModel.transform.eulerAngles = new Vector3(0, 50, 0);
            rotatePlayerDown.Normalize();
            isFacingDown = true;
            isFacingRight = true;
            isFacingLeft = false;
            isFacingUp = false;
        }
        if (isFacingLeft && rotateUp.IsPressed()) // Facing Left & W
        {
            var rotatePlayerUp = playerModel.transform.eulerAngles = new Vector3(0, -130, 0);
            rotatePlayerUp.Normalize();
            isFacingUp = true;
            isFacingLeft = true;
            isFacingRight = false;
            isFacingDown = false;
        }
        if (isFacingLeft && rotateUp.IsPressed() && rotateLeft.IsPressed()) // Facing Left & W + A
        {
            var rotatePlayerUp = playerModel.transform.eulerAngles = new Vector3(0, -140, 0);
            rotatePlayerUp.Normalize();
            isFacingUp = true;
            isFacingLeft = true;
            isFacingRight = false;
            isFacingDown = false;
        }
        if (isFacingLeft && rotateDown.IsPressed()) // Facing Left & S
        {
            var rotatePlayerDown = playerModel.transform.eulerAngles = new Vector3(0, -110, 0);
            rotatePlayerDown.Normalize();
            isFacingDown = true;
            isFacingLeft = true;
            isFacingRight = false;
            isFacingUp = false;
        }
        if (isFacingLeft && rotateDown.IsPressed() && rotateLeft.IsPressed()) // Facing Left & S + A
        {
            var rotatePlayerDown = playerModel.transform.eulerAngles = new Vector3(0, -120, 0);
            rotatePlayerDown.Normalize();
            isFacingDown = true;
            isFacingLeft = true;
            isFacingRight = false;
            isFacingUp = false;
        }
    }

}
