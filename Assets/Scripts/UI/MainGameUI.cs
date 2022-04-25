using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] TMP_InputField ipName;
    [SerializeField] PanelConnect pnlConnect;
    [SerializeField] PanelStatus pnlStatus;
    [SerializeField] PanelJoin pnlJoin;

    private Dictionary<PanelType, BasePanel> dictPanels;

    public System.Action<string> OnConnect;

    private void Awake()
    {
        OnConnect = pnlConnect.OnConnect;
    }

    private void Start()
    {
        dictPanels = new Dictionary<PanelType, BasePanel>();
        foreach (var pnl in GetComponentsInChildren<BasePanel>())
            dictPanels[pnl.type] = pnl;
    }

    public void Show(PanelType type)
    {
        foreach (var pnl in dictPanels.Values)
            pnl.Hide();

        dictPanels[type].Show();
    }
}
