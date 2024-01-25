using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimePlayerData : MonoBehaviour
{
    private static bool _initializeData = false;
    private static PlayerData _playerData = new PlayerData();
    public static PlayerData PlayerData { get { return _playerData; } }
    public static bool InitializeData { set { _initializeData = value; } }

    private void Awake()
    {
        if (_initializeData == false)
        {
            InitializePlayerDefaultValue();
            _initializeData = true;
        }
    }

    public static void InitializePlayerDefaultValue()
    {
        _playerData = new PlayerData { MaxHP = 100, CurrentHP = 100, MaxStamina = 100, CurrentStamina = 20, HPBottles = 2, Position = new Vector3(0f, 0f, 0f), Quaternion = new Quaternion(0f, 0f, 0f, 0f), Exp = 200, Gold = 200, BossKillPoint = 1 };
    }

    public static PlayerData GetPlayerData()
    {
        return _playerData;
    }

    public static void LoadPlayerData(PlayerData playerData)
    {
        _playerData = playerData;
    }

    private void Update()
    {
        if (_playerData.CurrentHP <= 0)
        {
            StartCoroutine(Defeat());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseHPBottle();
        }
    }

    IEnumerator Defeat()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject playerBox = GameObject.FindWithTag("PlayerBox");

        playerBox.GetComponent<CapsuleCollider>().enabled = false;

        player.GetComponent<Animator>().CrossFade("PlayerDeath", 0f);

        player.GetComponent<PlayerMovementManagement>().enabled = false;
        player.GetComponent<PlayerWeaponManagement>().enabled = false;

        RuntimeEquipmentData.InitializeData = false;
        RuntimeSkillData.InitializeData = false;
        RuntimeQuestData.InitializeData = false;
        _initializeData = false;

        RuntimeSkillData.SkillDictionary = new Dictionary<string, Skill>();
        //RuntimeQuestData.QuestData = null;
        //_playerData = null;
        //RuntimeEquipmentData.EquipmentData = null;
        // only skill data need to initialize

        GameObject defeatUI = GameObject.FindWithTag("DefeatUI").transform.GetChild(0).gameObject;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(2f);
        defeatUI.SetActive(true);
    }

    private void UseHPBottle()
    {
        if (PlayerData.HPBottles >= 1)
        {
            if (PlayerData.CurrentHP + 25 > PlayerData.MaxHP)
            {
                PlayerData.CurrentHP = PlayerData.MaxHP;
            }
            else
            {
                PlayerData.CurrentHP += 25;
            }

            PlayerData.HPBottles -= 1;
        }
    }
}
