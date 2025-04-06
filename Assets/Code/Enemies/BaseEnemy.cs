using System;
using Mono.Cecil.Cil;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BaseEnemy : Entity
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hitbox")) {
            var info = other.GetComponent<Hitbox>();
            TakeDamage(info.damage);
            if (info.destroyOnHit)
                Destroy(other.gameObject);
        }
    }

    protected override void OnDeath() {
        Destroy(gameObject);
    }
}
