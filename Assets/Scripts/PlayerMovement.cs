using UnityEngine;
using UnityEngine.InputSystem; // Namespace wajib untuk Input System baru

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;

    [Header("Input Setup")]
    // Referensi ke Action Asset yang sudah dibuat di Editor
    public InputActionReference moveActionRef;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.down;

    private Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // --- PENTING: Input Action harus di-Enable/Disable manual ---
    void OnEnable()
    {
        moveActionRef.action.Enable();
        // TODO 1: Aktifkan (Enable) action reference agar input bisa terbaca
        // ...
    }

    void OnDisable()
    {
        moveActionRef.action.Disable();
        // TODO 2: Matikan (Disable) action reference untuk mencegah memory leak/error
        // ...
    }


    void Update()
    {
        // TODO 3: Baca nilai Vector2 dari Input Action
        // Hint: Gunakan .action.ReadValue<Vector2>()
        // moveInput = ... 
        moveInput = moveActionRef.action.ReadValue<Vector2>();
        float isMoving = moveInput.sqrMagnitude;
        animator.SetFloat("isMoving", isMoving);

        if (isMoving > 0.01f)
        {
            moveInput = moveInput.normalized;
            lastMoveDirection = moveInput;

            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);

            animator.SetFloat("LastX", lastMoveDirection.x);
            animator.SetFloat("LastY", lastMoveDirection.y);
        } 
        
    }

    void FixedUpdate()
    {
        // TODO 4: Gerakkan karakter menggunakan Rigidbody Position
        // Rumus: Posisi Saat Ini + (Input * Kecepatan * FixedDeltaTime)
        // rb.MovePosition(...);
        rb.MovePosition( rb.position + (moveInput * moveSpeed * Time.fixedDeltaTime));
    }
}