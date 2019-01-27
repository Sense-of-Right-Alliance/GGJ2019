using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Fruitz;

public class PlayerNameText : MonoBehaviour
{
    public Text NameText;
    public float Offset = 0.5f;

    private Transform target;
    private Identity identity;

    public void Set(Transform t, Identity i)
    {
        target = t;
        identity = i;

        NameText.text = identity.Name;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = target.position;
            newPos.y += Offset;
            transform.position = newPos;
        }
    }
}
