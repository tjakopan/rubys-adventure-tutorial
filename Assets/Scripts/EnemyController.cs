using UnityEngine;

public class EnemyController : MonoBehaviour {
  private Rigidbody2D _rigidbody2D;
  private float _timer;
  private int _direction = 1;
  private Animator _animator;
  private bool _broken = true;

  public float Speed = 3.0f;
  public bool Vertical;
  public float ChangeTime = 3.0f;

  // Start is called before the first frame update
  private void Start() {
    _rigidbody2D = GetComponent<Rigidbody2D>();
    _timer = ChangeTime;
    _animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  private void Update() {
    if (!_broken) {
      return;
    }
    
    _timer -= Time.deltaTime;
    if (_timer < 0) {
      _direction = -_direction;
      _timer = ChangeTime;
    }

    Vector2 position = _rigidbody2D.position;
    if (Vertical) {
      position.y += Time.deltaTime * Speed * _direction;
      _animator.SetFloat("Move X", 0);
      _animator.SetFloat("Move Y", _direction);
    } else {
      position.x += Time.deltaTime * Speed * _direction;
      _animator.SetFloat("Move X", _direction);
      _animator.SetFloat("Move Y", 0);
    }

    _rigidbody2D.MovePosition(position);
  }

  private void OnCollisionEnter2D(Collision2D other) {
    RubyController player = other.gameObject.GetComponent<RubyController>();
    if (player != null) {
      player.ChangeHealth(-1);
    }
  }

  internal void Fix() {
    _broken = false;
    _rigidbody2D.simulated = false;
    _animator.SetTrigger("Fixed");
  }
}
