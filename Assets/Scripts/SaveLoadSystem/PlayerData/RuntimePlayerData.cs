using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimePlayerData : MonoBehaviour
{
    private static bool _initializeData = false;
    private static PlayerData _playerData = new PlayerData();
    public static PlayerData PlayerData { get { return _playerData; } }

    private void Awake()
    {
        if (_initializeData == false)
        {
            InitializePlayerDefaultValue();
            _initializeData = true;
            Debug.Log("osdfjosdif");
        }
    }

    public static void InitializePlayerDefaultValue()
    {
        _playerData = new PlayerData { MaxHP = 100, CurrentHP = 100, Position = new Vector3(0f, 0f, 0f), Quaternion = new Quaternion(0f, 0f, 0f, 0f), Exp = 1000, Gold = 1000, BossKillPoint = 3 };
    }

    public static PlayerData GetPlayerData()
    {
        return _playerData;
    }

    public static void LoadPlayerData(PlayerData playerData)
    {
        _playerData = playerData;
    }
}
