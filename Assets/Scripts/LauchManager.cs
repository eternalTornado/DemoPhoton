using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LauchManager : MonoBehaviourPunCallbacks
{
    [SerializeField] MainGameUI gameUI;

    void Start()
    {
        gameUI.OnConnect += OnClickedConnect;

        gameUI.Show(PanelType.CONNECT);
    }

    void OnDestroy()
    {
        gameUI.OnConnect -= OnClickedConnect;
    }

    private void ConnectToPhotoServer()
    {
        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.LogError("Cnnetcted to master ne with name: " + PhotonNetwork.NickName);
    }

    public override void OnConnected()
    {
        base.OnConnected();

        Debug.LogError("OnConnected ne");
    }

    public void OnClickedConnect(string name)
    {
        PhotonNetwork.NickName = name;
        ConnectToPhotoServer();
    }
}
