using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivitySettings : MonoBehaviour
{
    [SerializeField] private Text _mouseSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mouseSensitivity.text = "" + RuntimePlayerData.PlayerData.MouseSensitivity;
    }

    public void Minus()
    {
        RuntimePlayerData.PlayerData.MouseSensitivity -= 1;
    }

    public void Plus()
    {
        RuntimePlayerData.PlayerData.MouseSensitivity += 1;
    }
}
