using UnityEngine;

public class ObjectController : MonoBehaviour {
    public Transform @object;
    public Transform A, B;
    public float speed;

    public bool isEnemy;
    public bool lookRight;

    private Vector3 target;
    private SpriteRenderer spriteRenderer;

    private void Start () {
        spriteRenderer = @object.gameObject.GetComponent<SpriteRenderer> ();
        target = A.position;
        @object.position = A.position;

        if (isEnemy)
            spriteRenderer.flipX = lookRight;
    }

    private void Update () {
        @object.position = Vector3.MoveTowards (@object.position, target, speed * Time.deltaTime);

        if (@object.position == target) {
            target = (target == B.position) ? A.position : B.position;

            if (isEnemy) {
                lookRight = !lookRight;
                spriteRenderer.flipX = lookRight;
            }
        }
    }
}