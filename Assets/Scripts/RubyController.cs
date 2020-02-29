using UnityEngine;

public class RubyController : MonoBehaviour
{
    private int _currentHealth;
    private Rigidbody2D _rigidbody2D;
    private bool _isInvincible;
    private float _invincibleTimer;

    public int MaxHealth = 5;
    public float Speed = 3.0f;
    public int Health => _currentHealth;
    public float TimeInvincible = 2.0f;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _currentHealth = MaxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = _rigidbody2D.position;
        position.x += Speed * horizontal * Time.deltaTime;
        position.y += Speed * vertical * Time.deltaTime;

        _rigidbody2D.MovePosition(position);

        if (_isInvincible)
        {
            _invincibleTimer -= Time.deltaTime;
            if (_invincibleTimer < 0)
            {
                _isInvincible = false;
            }
        }
    }

    internal void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (_isInvincible)
                return;

            _isInvincible = true;
            _invincibleTimer = TimeInvincible;
        }
        
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, MaxHealth);
        Debug.Log($"{_currentHealth}/{MaxHealth}");
    }
}