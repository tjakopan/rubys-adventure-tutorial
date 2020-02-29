using UnityEngine;

public class RubyController : MonoBehaviour
{
    private int _currentHealth;
    private Rigidbody2D _rigidbody2D;

    public int MaxHealth = 5;
    public float Speed = 3.0f;
    public int Health => _currentHealth;

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
    }

    internal void ChangeHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, MaxHealth);
        Debug.Log($"{_currentHealth}/{MaxHealth}");
    }
}