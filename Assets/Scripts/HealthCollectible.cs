using UnityEngine;

public class HealthCollectible : MonoBehaviour {
  public GameObject HealthEffectPrefab;

  private void OnTriggerEnter2D(Collider2D other) {
    var rubyController = other.GetComponent<RubyController>();
    if (rubyController != null) {
      if (rubyController.Health < rubyController.MaxHealth) {
        Instantiate(HealthEffectPrefab, transform.position + Vector3.up * 1f, Quaternion.identity);
        rubyController.ChangeHealth(1);
        Destroy(gameObject);
      }
    }
  }
}
