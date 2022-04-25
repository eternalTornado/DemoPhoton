using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MainGameUI : MonoBehaviour
{
    [SerializeField] PanelConnect pnlConnect;
    [SerializeField] PanelStatus pnlStatus;
    [SerializeField] PanelJoin pnlJoin;

    private Dictionary<PanelType, BasePanel> dictPanels;

    public Action<string> OnConnect
    {
        get
        {
            return pnlConnect.OnConnect;
        }
        set
        {
            pnlConnect.OnConnect = value;
        }
    }

    public Action OnJoinRandomRoom 
    { 
        get { return pnlJoin.OnJoinRandomRoom; }
        set { pnlJoin.OnJoinRandomRoom = value; }
    }

    private void Awake()
    {
        dictPanels = new Dictionary<PanelType, BasePanel>();
        foreach (var pnl in GetComponentsInChildren<BasePanel>())
        {
            dictPanels[pnl.type] = pnl;
            pnl.Hide();
        }
    }

    public void Show(PanelType type)
    {
        foreach (var pnl in dictPanels.Values)
            pnl.Hide();

        dictPanels[type].Show();
    }

    public void ShowStatus(string textStatus)
    {
        foreach (var pnl in dictPanels.Values)
            pnl.Hide();

        pnlStatus.Show(textStatus);
    }
}
