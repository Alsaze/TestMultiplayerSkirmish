using System;
using TMPro;
using UnityEngine;

public class GetEnterCode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputText;
    private string _getCode;

    public void GetCode()
    {
        _getCode = inputText.text;
        Debug.Log(_getCode);
    }
}
