using UnityEngine;

public class Arrow : MonoBehaviour
{

  public float speed = 2;
  public float strong;

  private void Update()
  {
    transform.Translate(Vector2.right * speed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      other.GetComponent<PlayerHealth>().RemoveHealth(strong);
      Destroy(gameObject);
    }
  }
}