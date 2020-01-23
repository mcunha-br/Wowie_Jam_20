using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
  public Camera playerCamera;
  public CameraPosition cameraPosition;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      playerCamera.gameObject.transform.position = cameraPosition.value;
    }
    else if (other.CompareTag("Shot"))
    {
      Destroy(other.gameObject);
    }
  }

}
