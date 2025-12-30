using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _jumpAction; // 예시: 새로운 인풋 추가

    private void Awake()
    {
        if (TryGetComponent(out _playerInput))
        {
            _moveAction = _playerInput.actions["Move"];
            // _jumpAction = _playerInput.actions["Jump"];
        }
    }

    private void OnEnable()
    {
        // 점프와 같은 일회성 액션은 이벤트 방식이 효율적입니다.
        if (_jumpAction != null) _jumpAction.performed += OnJump;
    }

    private void OnDisable()
    {
        if (_jumpAction != null) _jumpAction.performed -= OnJump;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 input = _moveAction?.ReadValue<Vector2>() ?? Vector2.zero;
        if (input == Vector2.zero) return;

        Vector3 moveDir = new Vector3(input.x, 0, input.y);
        transform.Translate(moveDir * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        // 점프 로직 처리
        Debug.Log("Jumped!");
    }
}