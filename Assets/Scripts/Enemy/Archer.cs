using System.Collections;
using UnityEngine;

public class Archer : EnemyBase {

    public GameObject arrow;
    public Transform pointArrow;

    private Animator anim => GetComponent<Animator> ();

    private float countdown = Mathf.Infinity; 
    private float timer;

    private void Update () {
        timer += Time.deltaTime;
        if (timer >= countdown && !death) {
            timer = 0;
            anim.SetTrigger ("attack");
            Invoke ("SpawnArrow", 0.3f);
        }
    }

    private void SpawnArrow () {
        Instantiate (arrow, pointArrow.position, pointArrow.rotation);
        source.PlayOneShot (attack, 0.15f);
    }

    protected override void OnDeath () {
        death = true;
        StartCoroutine ("Death");
    }

    private IEnumerator Death () {
        GetComponent<CapsuleCollider2D> ().enabled = false;
        anim.SetTrigger ("death");
        source.PlayOneShot (dead, 3f);
        yield return new WaitForSeconds (1);
        Destroy (gameObject);
    }

    protected override void OnHit () {
        source.PlayOneShot (damage, 5);
    }

    private void OnBecameVisible () {
        countdown = 3;
    }

}