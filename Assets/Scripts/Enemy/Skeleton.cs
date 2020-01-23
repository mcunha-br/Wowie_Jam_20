using UnityEngine;

public class Skeleton : EnemyBase {

    public float distanceForFollow;
    public float distanceForAttack;
    public float countdown = 1;
    public bool lookRight = true;

    private Vector3 startPos;
    private Animator anim;
    private float timer;
    private float speedCurrent = 0;
    private bool inAttack;

    private new void Start () {
        base.Start ();

        anim = GetComponent<Animator> ();
        source = GetComponent<AudioSource> ();
        startPos = transform.position;

        Flip ();
    }

    private void Update () {
        var newTarget = new Vector3 (player.position.x, transform.position.y, transform.position.z);
        var distance = Vector3.Distance (transform.position, newTarget);

        anim.SetFloat ("speed", speedCurrent);

        timer += Time.deltaTime;

        if (death) return;

        if (distance <= distanceForAttack) {
            if (timer >= countdown) {
                timer = 0;
                anim.SetTrigger ("attack");
                speedCurrent = 0;
                inAttack = true;
            }

        } else if (distance <= distanceForFollow && !inAttack) {
            Flip ();
            speedCurrent = speed;
            transform.position = Vector2.MoveTowards (transform.position, newTarget, speedCurrent * Time.deltaTime);

        } else if (distance > distanceForFollow) 
            transform.position = Vector2.MoveTowards (transform.position, startPos, speedCurrent * Time.deltaTime);
        
    }

    public void DisableAttack () => inAttack = false;

    protected override void OnDeath () {
        speedCurrent = 0;
        anim.SetTrigger ("death");
        Sound("DEATH");
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Destroy (gameObject, 1.1f);
    }

    private void Flip () {
        if (transform.position.x > player.position.x && !lookRight || transform.position.x < player.position.x && lookRight) {
            lookRight = !lookRight;

            transform.rotation = (lookRight) ? Quaternion.Euler (0, 180, 0) : Quaternion.Euler (0, 0, 0);
        }
    }

    public void Sound (string audio) {
        switch (audio) {
            case "ATTACK":
                source.PlayOneShot (attack);
                break;

            case "DAMAGE":
                source.PlayOneShot (damage);
                break;

            case "DEATH":
                source.PlayOneShot (dead);
                break;
        }
    }

    protected override void OnHit () {
        Sound ("DAMAGE");
    }
}