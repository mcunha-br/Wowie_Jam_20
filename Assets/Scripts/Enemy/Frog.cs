using UnityEngine;

public class Frog : EnemyBase {

    public float strong;
    public float distance;
    public AudioClip idle;
    public AudioClip jump;
    public Transform groundcheck;
    public bool facingRight;

    private Animator anim;
    private Rigidbody2D body;

    private new void Start () {
        base.Start ();

        anim = GetComponent<Animator> ();
        body = GetComponent<Rigidbody2D> ();
        source = GetComponent<AudioSource> ();
    }

    private void Update () {
        var ground = (!Physics2D.Raycast (groundcheck.position, Vector2.down, distance));

        anim.SetBool ("jump", ground);
        anim.SetFloat ("yPos", body.velocity.y);
    }

    protected override void OnDeath () {
        Sound("DEATH");
        spriteRenderer.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy (gameObject, 0.5f);
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag ("Player")) 
            other.gameObject.GetComponent<PlayerHealth> ().RemoveHealth (3);
    }

    private void Jump () {
        if(facingRight)
            body.AddForce (new Vector2(strong, strong), ForceMode2D.Impulse);
        else
            body.AddForce (new Vector2(-strong, strong), ForceMode2D.Impulse);

        Sound("JUMP");
    }

    public void Sound (string sound) {
        switch (sound) {
            case "IDLE":
                source.PlayOneShot (idle);
                break;

            case "DEATH":
                source.PlayOneShot (dead, 3);
                break;

            case "JUMP":
                source.PlayOneShot (jump);
                break;
        }
    }

    protected override void OnHit () {
        Sound("DEATH");
    }

    private void Randomize() {
        var rand = Random.Range(0, 100);
        if(rand <= 30) {
            Jump();
        }
    }

    private void OnBecameVisible() {
        anim.Play("idle");
        InvokeRepeating("Randomize", 0, 2);
    }

    private void OnBecameInvisible() {
        anim.Play("NONE");
        CancelInvoke("Randomize");
    }
}