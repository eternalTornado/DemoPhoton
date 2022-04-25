using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PanelConnect : BasePanel
{
    [SerializeField] TMP_InputField ipName;

    public Action<string> OnConnect;

    public void OnClickedConnect()
    {
        if (string.IsNullOrEmpty(ipName.text)) return;

        OnConnect?.Invoke(ipName.text);
    }
}
