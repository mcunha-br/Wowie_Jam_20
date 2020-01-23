using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCameraPosition : MonoBehaviour
{

  public Vector3 startingPosition;

  void Start()
  {
    transform.position = startingPosition;
  }
}
