using System.Collections;
using UnityEngine;

public class Enemy : EnemyBase {

    protected override void OnDeath () => Destroy (transform.parent.gameObject);

    protected override void OnHit () {
    }
}