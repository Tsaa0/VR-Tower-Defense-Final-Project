using System;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeTower : BaseTower {
    public float attackDuration = 2f;
    public Vector3 hitboxSize;
    public Vector3 hitboxOffset;

    protected override void OnDeath() { }

    protected override void Attack() {
        if (currentAttackCooldown > 0) return;
        currentAttackCooldown = attackCooldown;
        var temp = SpawnHitbox();
        Destroy(temp, attackDuration);
    }

    private GameObject SpawnHitbox() {
        Vector3 offset = transform.forward * hitboxOffset.z + transform.right * hitboxOffset.x +
                         transform.up * hitboxOffset.y;
        //TODO Change where it spawns
        GameObject hitbox = Instantiate(spawnedObject, transform.position + offset, transform.rotation);
        var script = hitbox.GetComponent<Hitbox>();
        script.damage = damage;
        script.destroyOnHit = false;
        return hitbox;
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemy")) {
            transform.LookAt(other.transform);
            Attack();
        }
    }

    private void Update() {
        MoreDebug.DrawCircle(transform.position, detectionRadius, 32, Color.red);
        currentAttackCooldown -= Time.deltaTime;
    }
}