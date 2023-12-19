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
            Quests = new Quest[] { new Quest() {Id = "001" ,Title = "Quest 1", Content = "Di den nga 3 dau tien" , State = "doing", Type = "moving", Position = new Vector3(11, 0.74f, 16)},
                    new Quest() {Id = "002", Title = "Quest 2", Content = "Danh bai quai vat xuat hien" , State = "lock", Type = "attack", Position = new Vector3(11, 0.74f, 16), Progress = 0, Condition = 5 },
                    new Quest() {Id = "003" ,Title = "Quest 3", Content = "Di tiep ve ben phai" , State = "lock", Type = "moving", Position = new Vector3(37.7f, 0.93f, 10.0f)},
                    new Quest() {Id = "004" ,Title = "Quest 4", Content = "Danh bai quai vat 2 xuat hien" , State = "lock", Type = "attack", Position = new Vector3(37.7f, 0.93f, 10.0f), Progress = 0, Condition = 3},
                    new Quest() {Id = "005" ,Title = "Quest 5", Content = "Di ve nga 3" , State = "lock", Type = "moving", Position = new Vector3(11, 0.74f, 16)},
                    new Quest() {Id = "005" ,Title = "Quest 5", Content = "Di thang den chan cau" , State = "lock", Type = "moving", Position = new Vector3(15, 4.4f, 60)},
                    new Quest() {Id = "005" ,Title = "Quest 5", Content = "Complete Quest" , State = "lock", Type = "moving", Position = new Vector3(111, 111, 111)},

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
