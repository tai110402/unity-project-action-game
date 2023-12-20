using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeQuestData : MonoBehaviour
{
    private static bool _initializeData = false;
    private static QuestData _questData;
    public static QuestData QuestData { get { return _questData; } set { _questData = value; } }

    // Start is called before the first frame update
    private void Awake()
    {
        if (_initializeData == false)
        {
            InitializeQuestsDefaultValue();
            _initializeData = true;
        }
    }

    public static void InitializeQuestsDefaultValue()
    {
        _questData = new QuestData()
        {
            Quests = new Quest[] { new Quest() {Id = "001" , State = "doing", Type = "moving", Position = new Vector3(11, 0.74f, 16),Title = "Quest 1", Content = "Di den nga 3 dau tien"},
                    new Quest() {Id = "002" , State = "lock", Type = "attack", Position = new Vector3(11, 0.74f, 16), Progress = 0, Condition = 5 , Title = "Quest 2", Content = "Danh bai quai vat xuat hien"},
                    new Quest() {Id = "003" , State = "lock", Type = "moving", Position = new Vector3(37.7f, 0.93f, 10.0f), Title = "Quest 3", Content = "Di tiep ve ben phai"},
                    new Quest() {Id = "004" , State = "lock", Type = "attack", Position = new Vector3(37.7f, 0.93f, 10.0f), Progress = 0, Condition = 3, Title = "Quest 4", Content = "Danh bai quai vat 2 xuat hien"},
                    new Quest() {Id = "005" , State = "lock", Type = "moving", Position = new Vector3(11, 0.74f, 16) ,Title = "Quest 5", Content = "Di ve nga 3"},
                    new Quest() {Id = "006" , State = "lock", Type = "moving", Position = new Vector3(15, 4.4f, 60),Title = "Quest 5", Content = "Di thang den chan cau" },
                    new Quest() {Id = "007" , State = "lock", Type = "moving", Position = new Vector3(40, 9.84f, 69.42f),Title = "Quest 5", Content = "Den ben kia cau" },
                    new Quest() {Id = "008" , State = "lock", Type = "moving", Position = new Vector3(76, 0.5f, 89.34f),Title = "Quest 5", Content = "Di den bo song" },
                    new Quest() {Id = "009" , State = "lock", Type = "attack", Position = new Vector3(83.2f, 1.25f, 99f), Progress = 0, Condition = 4, Title = "Quest 4", Content = "Danh bai quai vat 3 xuat hien"},
                    new Quest() {Id = "010" , State = "lock", Type = "moving", Position = new Vector3(84, 0.9f, 148.5f),Title = "Quest 5", Content = "Di den hang dong" },


                    new Quest() {Id = "100" , State = "lock", Type = "moving", Position = new Vector3(111, 111, 111) ,Title = "Quest 5", Content = "Complete Quest"},

            }
        };
    }

    public static Quest GetCurrentQuest()
    {
        foreach(Quest quest in _questData.Quests)
        {
            if (quest.State == "doing")
            {
                return quest;
            }
        }
        return null;
    }

    public static void CompleteQuest()
    {
        for (int i = 0; i < _questData.Quests.Length; i++)
        {
            if (_questData.Quests[i].State == "doing")
            {
                _questData.Quests[i].State = "complete";
                if (_questData.Quests[i+1] != null)
                {
                    _questData.Quests[i + 1].State = "doing";
                }
                break;
            }
        }
    }

    public static void ProgressQuest()
    {
        Quest currentQuest = GetCurrentQuest();
        if ((currentQuest.Progress+1) == currentQuest.Condition)
        {
            CompleteQuest();
        } else
        {
            currentQuest.Progress += 1;
        }
    }

    public static QuestData GetQuestData()
    {
        return _questData;
    }

    public static void LoadQuestData(QuestData questData)
    {
        _questData = questData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
