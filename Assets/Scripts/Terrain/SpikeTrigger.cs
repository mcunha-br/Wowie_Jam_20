using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
  public Transform respawnTransform;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      other.transform.position = respawnTransform.position;
      other.GetComponent<PlayerHealth>().RemoveHealth(1);
      other.GetComponent<PlayerMovement>().animator.SetTrigger("Hurt");
      other.GetComponent<PlayerMovement>().rb.velocity = Vector2.zero;
    }
  }
}
