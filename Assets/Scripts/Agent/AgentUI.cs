using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AgentUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtName;
    [SerializeField] Image imgHealth;

    public void UpdateName(string name)
    {
        txtName.text = name;
    }

    public void UpdateHealthBar(float value)
    {
        imgHealth.fillAmount = value;
    }
}
