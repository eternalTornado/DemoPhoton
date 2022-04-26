using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentStats : MonoBehaviour
{
    public float MaxHealth;
    public float Damage;

    private float currentHealth;
    private float percentHealth;

    public Action OnDie;

    private void Start()
    {
        currentHealth = MaxHealth;
    }

    public void UpdateHealth(float value)
    {
        currentHealth = value;
        currentHealth = Mathf.Clamp(currentHealth, 0f, MaxHealth);
        percentHealth = currentHealth / MaxHealth;

        if (currentHealth < Mathf.Epsilon)
            OnDie?.Invoke();
    }

    public void AddHealth(float value)
    {
        currentHealth += value;
        currentHealth = Mathf.Clamp(currentHealth, 0f, MaxHealth);
        percentHealth = currentHealth / MaxHealth;

        if (currentHealth < Mathf.Epsilon)
            OnDie?.Invoke();
    }

    public float GetPercentHealth() => percentHealth;
}
