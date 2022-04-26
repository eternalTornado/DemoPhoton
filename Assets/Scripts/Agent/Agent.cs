using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;
using Photon.Pun;

public class Agent : MonoBehaviourPunCallbacks
{
    [SerializeField] Camera characterCam;
    [SerializeField] SUPERCharacterAIO characterController;
    [SerializeField] AgentUI agentUI;
    [SerializeField] AgentStats agentStats;

    private void Start()
    {
        characterCam.enabled = photonView.IsMine;
        characterController.enabled = photonView.IsMine;

        agentUI.UpdateName(PhotonNetwork.NickName);
        agentStats.UpdateHealth(agentStats.MaxHealth);
        agentUI.UpdateHealthBar(agentStats.GetPercentHealth());
    }

    public void AddHealth(float value)
    {
        agentStats.AddHealth(value);
        agentUI.UpdateHealthBar(agentStats.GetPercentHealth());
    }
}
