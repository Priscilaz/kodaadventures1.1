using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Add this for Image

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;  // Changed colon to semicolon
    [SerializeField] private Image currenthealthBar;  // Changed colon to semicolon

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10f;  // Divide by max health (example value)
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10f;  // Update health bar
    }
}
