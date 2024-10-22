using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LocKey : MonoBehaviour
{
    [SerializeField] private string _lockey;
    TMP_Text _text;
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        if (_text && _lockey != "") 
        { 
            _text.text = LocalizationManager.Instance.GetLocalizedString(_lockey);
        }
    }

    void Update()
    {
        
    }
}
