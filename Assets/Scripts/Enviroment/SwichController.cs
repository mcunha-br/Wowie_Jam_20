using UnityEngine;

public class SwichController : MonoBehaviour {

    public Transform elevator;
    public Transform A, B;
    public float speed;
    public AudioClip swAudio;
    public AudioClip spAudio;

    public Sprite[] sprites;

    private bool onOff = false;
    private Vector3 target;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private void Start () {
        spriteRenderer = GetComponent<SpriteRenderer> ();
        audioSource = GetComponent<AudioSource>();

        target = A.position;
        elevator.position = A.position;
        spriteRenderer.sprite = sprites[0];
    }

    private void Update () {
        elevator.position = Vector3.MoveTowards (elevator.position, target, speed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D (Collider2D other) {

        var shoot = other.GetComponent<ShotMovement> ();

        if (shoot != null) {
            onOff = !onOff;

            if (onOff) {
                spriteRenderer.sprite = sprites[1];
                target = B.position;
            } else {
                spriteRenderer.sprite = sprites[0];
                target = A.position;
            }

            audioSource.PlayOneShot(swAudio);
            audioSource.PlayOneShot(spAudio);

            Destroy(other.gameObject);
        }
    }

    private void OnOff () {
        onOff = !onOff;

        if (onOff) {
            spriteRenderer.sprite = sprites[1];
            target = B.position;
        } else {
            spriteRenderer.sprite = sprites[0];
            target = A.position;
        }
    }
}