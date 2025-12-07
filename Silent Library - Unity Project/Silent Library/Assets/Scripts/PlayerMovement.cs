using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    InputAction moveAction;

    public float moveSpeed = 5f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Player/Move");
    }

    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        if (moveValue != Vector2.zero)
        {
            Vector2 moveDirection = new Vector2(moveValue.x, moveValue.y);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

}
