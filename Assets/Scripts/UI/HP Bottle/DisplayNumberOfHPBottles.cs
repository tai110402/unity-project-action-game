using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNumberOfHPBottles : MonoBehaviour
{
    [SerializeField] private Text numberOfHPBottle;

    // Update is called once per frame
    void Update()
    {
        numberOfHPBottle.text = "" + RuntimePlayerData.PlayerData.HPBottles;
    }
}
