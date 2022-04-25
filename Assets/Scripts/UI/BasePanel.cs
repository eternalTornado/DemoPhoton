using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    public PanelType type;
    [SerializeField] CanvasGroup cvGroup;
    public virtual void Show()
    {
        cvGroup.alpha = 1;
        cvGroup.interactable = true;
        cvGroup.blocksRaycasts = true;
    }

    public virtual void Hide()
    {
        cvGroup.alpha = 0;
        cvGroup.interactable = false;
        cvGroup.blocksRaycasts = false;
    }
}

public enum PanelType
{
    CONNECT,
    STATUS,
    JOIN,
}
