using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;
using Photon.Pun;

public class Agent : MonoBehaviourPunCallbacks
{
    [SerializeField] Camera characterCam;
    [SerializeField] SUPERCharacterAIO characterController;

    private void Start()
    {
        characterCam.enabled = photonView.IsMine;
        characterController.enabled = photonView.IsMine;
    }
}
