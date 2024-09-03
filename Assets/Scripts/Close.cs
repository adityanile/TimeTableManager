using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    public void OnClickClose()
    {
        UIManager.instance.mainUI.SetActive(true);
        UIManager.instance.AddlecUi.SetActive(false);
    }
}
