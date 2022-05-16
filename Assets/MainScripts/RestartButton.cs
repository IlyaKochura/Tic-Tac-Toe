using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Action Restart { get; set; }
    private Button _button;
    
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener( () => Restart.Invoke());
    }
    
}
