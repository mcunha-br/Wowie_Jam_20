using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{

  public Rigidbody2D rb;

  public float speed;

  Transform player;

  void Start()
  {
    var playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    player = playerTransform.GetChild(0).transform;
    Invoke("Collided", 5f);
  }

  void Update()
  {
    Move();
  }

  void Move()
  {
    transform.Translate(-Vector2.right * speed * Time.deltaTime);
    var x = transform.position.x;
    var y = player.position.y;
    transform.position = new Vector2(x, y);
  }

  public void Collided()
  {
    // Mostra particulas
    Destroy(gameObject);
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    var enemy = other.GetComponent<EnemyBase>();

    if (enemy != null)
    {
      enemy.ApplyDamage(1);
      Destroy(gameObject);
    }

  }

}