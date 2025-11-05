using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemConfig : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField X;
    [SerializeField]
    private TMP_InputField Y;
    [SerializeField]
    private TMP_InputField itemCount;
    [SerializeField]
    private Toggle toggle;

    public Vector2Int GetSlot()
    {
        return new Vector2Int(int.Parse(X.text), int.Parse(Y.text));
    }

    public int GetCount()
    {
        return int.Parse(itemCount.text);
    }

    public bool CanUseCount() => toggle.isOn;
}
