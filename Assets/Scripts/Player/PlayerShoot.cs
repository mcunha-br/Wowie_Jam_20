using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

  public GameObject shotPrefab;

  public Animator animator;

  public Transform shotOrigin;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      animator.SetTrigger("Attack");
      Invoke("Shoot", 0.5f);
    }
  }

  void Shoot()
  {
    Instantiate(shotPrefab, shotOrigin.position, transform.rotation);
  }
}
