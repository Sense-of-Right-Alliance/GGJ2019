using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject confirmDialog;

    public void ShowConfirmEnd()
    {
        confirmDialog.SetActive(true);
    }
}
