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

    public float moveSpeed = 5f;

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
        
        if (rotateUp.IsPressed() && isFacingRight)
        {
            var rotatePlayerUp = playerModel.transform.eulerAngles = new Vector3(0, 70, 0);
            rotatePlayerUp.Normalize();
            isFacingRight = true;
            isFacingLeft = false;
        }
        if (rotateUp.IsPressed() && rotateRight.IsPressed())
        {
            var rotatePlayerUpRight = playerModel.transform.eulerAngles = new Vector3(0, 35, 0);
            rotatePlayerUpRight.Normalize();
            isFacingRight = true;
            isFacingLeft = false;
        }
        if (rotateUp.IsPressed() && isFacingLeft)
        {
            var rotatePlayerUp = playerModel.transform.eulerAngles = new Vector3(0, 140, 0);
            rotatePlayerUp.Normalize();
            isFacingLeft = true;
            isFacingRight = false;
        }
        if (rotateUp.IsPressed() && rotateLeft.IsPressed())
        {
            var rotatePlayerUpLeft = playerModel.transform.eulerAngles = new Vector3(0, 110, 0);
            rotatePlayerUpLeft.Normalize();
            isFacingLeft = true;
            isFacingRight = false;
        }
        if (rotateDown.IsPressed() && isFacingRight)
        {
            var rotatePlayerDown = playerModel.transform.eulerAngles = new Vector3(0, -35, 0);
            rotatePlayerDown.Normalize();
            isFacingRight = true;
            isFacingLeft = false;
        }
        if (rotateDown.IsPressed() && isFacingLeft)
        {
            var rotatePlayerDown = playerModel.transform.eulerAngles = new Vector3(0, -140, 0);
            rotatePlayerDown.Normalize();
            isFacingLeft = true;
            isFacingRight = false;
        }
        if (rotateLeft.IsPressed())
        {
            var rotatePlayerLeft = playerModel.transform.eulerAngles = new Vector3(0, -180, 0);
            rotatePlayerLeft.Normalize();
            isFacingLeft = true;
            isFacingRight = false;
        }
        if (rotateRight.IsPressed())
        {
            var rotatePlayerRight = playerModel.transform.eulerAngles = new Vector3(0, 0, 0);
            rotatePlayerRight.Normalize();
            isFacingRight = true;
            isFacingLeft = false;            
        }
    }

}
