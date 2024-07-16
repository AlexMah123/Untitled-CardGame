using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStatComponent : MonoBehaviour
{
    [Header("Runtime Value")]
    public int healthAmount;

    //declaration of events
    public event Action<int> OnHealthModifiedEvent;

    public void InitializeComponent(PlayerStatsSO referencedStats)
    {
        healthAmount = referencedStats.health;
    }

    public void IncreaseHealth(int value)
    {
        ModifyHealthAmount(value);
    }

    public void DecreaseHealth(int value)
    {
        ModifyHealthAmount(-1 * value);
    }

    #region Internal Function
    private void ModifyHealthAmount(int value)
    {
        healthAmount += value;

        OnHealthModifiedEvent?.Invoke(healthAmount);
    }
    #endregion
}
