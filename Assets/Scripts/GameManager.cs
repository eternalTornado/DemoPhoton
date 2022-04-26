using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            float value = Random.Range(-20f, 20f);

            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(value, 0f, value), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Photon callbacks

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.LogError("Joined room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        Debug.LogError($"player {newPlayer.NickName} has just joined");
    }

    #endregion
}
