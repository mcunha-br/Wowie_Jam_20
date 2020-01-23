using System.Collections;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour {

    public float speed = 2;
    public float health;
    public AudioClip attack;
    public AudioClip damage;
    public AudioClip dead;

    protected bool lookLeft;
    protected bool death;
    protected SpriteRenderer spriteRenderer;
    protected Transform player;
    protected AudioSource source;

    protected void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        source = GetComponent<AudioSource> ();
        player = GameObject.FindWithTag ("Player").transform;
    }

    public void ApplyDamage (float damage) {
        health -= damage;
        StartCoroutine (TakeDamage ());

        if (health <= 0 && !death) {
            death = true;
            OnDeath ();

        } else
            OnHit ();

    }

    protected IEnumerator TakeDamage () {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds (0.1f);
        spriteRenderer.color = Color.white;
    }

    protected abstract void OnDeath ();
    protected abstract void OnHit ();

}