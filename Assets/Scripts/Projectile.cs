using UnityEngine;

public class Projectile : MonoBehaviour {
  private Rigidbody2D _rigidbody2D;

  // Start is called before the first frame update
  private void Awake() {
    _rigidbody2D = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  private void Update() {
    if (transform.position.magnitude > 1000.0f) {
      Destroy(gameObject);
    }
  }

  internal void Launch(Vector2 direction, float force) {
    _rigidbody2D.AddForce(direction * force);
  }

  private void OnCollisionEnter2D(Collision2D other) {
    var enemyController = other.collider.GetComponent<EnemyController>();
    if (enemyController != null) {
      enemyController.Fix();
    }

    Destroy(gameObject);
  }
}
