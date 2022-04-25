using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LauchManager : MonoBehaviourPunCallbacks
{
    [SerializeField] MainGameUI gameUI;

    void Start()
    {
        gameUI.OnConnect += OnClickedConnect;
        gameUI.OnJoinRandomRoom += OnJoinRandomRoom;

        gameUI.Show(PanelType.CONNECT);
    }

    void OnDestroy()
    {
        gameUI.OnConnect -= OnClickedConnect;
        gameUI.OnJoinRandomRoom -= OnJoinRandomRoom;
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

        gameUI.Show(PanelType.JOIN);
    }

    public override void OnConnected()
    {
        base.OnConnected();

        Debug.LogError("OnConnected ne");
    }

    private void OnClickedConnect(string name)
    {
        PhotonNetwork.NickName = name;
        ConnectToPhotoServer();

        gameUI.ShowStatus("Connecting");
    }

    private void OnJoinRandomRoom()
    {
        if(PhotonNetwork.CurrentRoom != null)
        {
            Debug.LogError("already in room: " + PhotonNetwork.CurrentRoom.Name);
            return;
        }

        PhotonNetwork.JoinRandomRoom();
    }

    private void CreateAndJoinRandomRoom()
    {
        Debug.LogError("Create and join random room");

        string roomName = "Room " + Random.Range(0, 1000);

        RoomOptions options = new RoomOptions();
        options.IsOpen = true;
        options.IsVisible = true;
        options.MaxPlayers = 5;

        PhotonNetwork.CreateRoom(roomName, options);
    }

    #region Photon callback

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);

        Debug.LogError("Join random room failed");
        CreateAndJoinRandomRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);

        Debug.LogError("Create room failed");
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();

        Debug.LogError("Create room success");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.LogError("Joined roon: " + PhotonNetwork.CurrentRoom.Name);
    }

    #endregion
}
