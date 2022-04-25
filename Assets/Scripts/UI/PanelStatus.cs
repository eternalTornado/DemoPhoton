using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelStatus : BasePanel
{
    [SerializeField] TextMeshProUGUI txtStatus;

    public void Show(string text)
    {
        Show();
        txtStatus.text = text;
    }
}
