using UnityEngine;
using UnityEngine.SceneManagement;

public enum KnightState
{
    Die = -1,
    Idle = 0,
    Walk = 1,
    Fall = 2,
    Jump = 3,
    Attack = 4
}

[RequireComponent(typeof(Rigidbody2D))]
public class KnightController : MonoBehaviour
{
    public GroundDetector Detector;
    public Animator KnightAnimator;
    public float Speed = 5f;
    public float JumpPower = 8f;

    private Rigidbody2D _rigidbody;
    private KnightState _state;

    private bool _jumpRequest;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _state = KnightState.Idle; 
    }

    void Update()
    {
        if (Detector.IsGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            _jumpRequest = true;
        }

        if (Detector.IsGrounded)
        {
            if (_jumpRequest)
            {
                Jump();
            }
            else
            {
                SetState(KnightState.Walk, "Walk"); // selalu jalan
            }
        }
        else
        {
            if (_state != KnightState.Fall)
                SetState(KnightState.Fall, "Jump");
        }
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.linearVelocity;
        velocity.x = Speed;
        _rigidbody.linearVelocity = velocity;

        Vector3 scale = transform.localScale;
        if (scale.x < 0) scale.x *= -1f;
        transform.localScale = scale;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        SetState(KnightState.Jump, "Jump");
        _jumpRequest = false;
    }

    private void SetState(KnightState newState, string animationName)
    {
        if (_state != newState)
        {
            KnightAnimator.Play(animationName);
            _state = newState;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            GameManager.instance.GameOver();
        }
    }
}
