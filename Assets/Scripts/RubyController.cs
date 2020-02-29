using UnityEngine;

public class RubyController : MonoBehaviour {
  private int _currentHealth;
  private Rigidbody2D _rigidbody2D;
  private bool _isInvincible;
  private float _invincibleTimer;
  private Animator _animator;
  private Vector2 _lookDirection = new Vector2(1, 0);

  public int MaxHealth = 5;
  public float Speed = 3.0f;
  public int Health => _currentHealth;
  public float TimeInvincible = 2.0f;
  public GameObject ProjectilePrefab;

  // Start is called before the first frame update
  private void Start() {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    _currentHealth = MaxHealth;
    _animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  private void Update() {
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector2 move = new Vector2(horizontal, vertical);
    if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) {
      _lookDirection.Set(move.x, move.y);
      _lookDirection.Normalize();
    }

    _animator.SetFloat("Look X", _lookDirection.x);
    _animator.SetFloat("Look Y", _lookDirection.y);
    _animator.SetFloat("Speed", move.magnitude);

    Vector2 position = _rigidbody2D.position;
    position += move * (Speed * Time.deltaTime);

    _rigidbody2D.MovePosition(position);

    if (_isInvincible) {
      _invincibleTimer -= Time.deltaTime;
      if (_invincibleTimer < 0) {
        _isInvincible = false;
      }
    }

    if (Input.GetKeyDown(KeyCode.C)) {
      Launch();
    }
  }

  internal void ChangeHealth(int amount) {
    if (amount < 0) {
      if (_isInvincible)
        return;

      _animator.SetTrigger("Hit");
      _isInvincible = true;
      _invincibleTimer = TimeInvincible;
    }

    _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, MaxHealth);
    Debug.Log($"{_currentHealth}/{MaxHealth}");
  }

  private void Launch() {
    GameObject projectileObject =
      Instantiate(ProjectilePrefab, _rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);
    Projectile projectile = projectileObject.GetComponent<Projectile>();
    projectile.Launch(_lookDirection, 300);
    _animator.SetTrigger("Launch");
  }
}
