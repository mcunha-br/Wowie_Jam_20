using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{

  public TextMeshProUGUI healthText;

  public FloatVariable playerHealth;

  public void UpdateHealth()
  {
    healthText.text = "x " + playerHealth.Value.ToString();

  }
}
