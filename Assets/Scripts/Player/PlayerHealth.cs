using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]float maxHealth = 100;
    [SerializeField]float currentHealth;
    [SerializeField]UIManager uIManager;
    [SerializeField]GameObject deathUI;
    void Awake()
    {
        currentHealth = maxHealth;
    }
    public void LoseHealth(float healthToLose)
    {
        currentHealth -= healthToLose;
        uIManager.UpdateHealthText(currentHealth);
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        deathUI.SetActive(true);
    }
}
