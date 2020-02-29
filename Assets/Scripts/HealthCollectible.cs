﻿using UnityEngine;

public class HealthCollectible : MonoBehaviour {
  private void OnTriggerEnter2D(Collider2D other) {
    RubyController controller = other.GetComponent<RubyController>();
    if (controller != null) {
      if (controller.Health < controller.MaxHealth) {
        controller.ChangeHealth(1);
        Destroy(gameObject);
      }
    }
  }
}
