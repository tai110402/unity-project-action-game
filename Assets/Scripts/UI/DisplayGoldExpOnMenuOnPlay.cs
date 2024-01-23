using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGoldExpOnMenuOnPlay : MonoBehaviour
{
    [SerializeField] private Text _expText;
    [SerializeField] private Text _goldText;

    // Update is called once per frame
    void Update()
    {
        _expText.text = "E: " + RuntimePlayerData.PlayerData.Exp.ToString();
        _goldText.text = "G: " + RuntimePlayerData.PlayerData.Gold.ToString();
    }
}

