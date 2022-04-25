using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PanelJoin : BasePanel
{
    public Action OnJoinRandomRoom;

    public void OnClickedJoinRandom()
    {
        OnJoinRandomRoom?.Invoke();
    }
}
