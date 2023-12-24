using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySkillBlock : MonoBehaviour
{
    [SerializeField] private string _questId;
    [SerializeField] private GameObject _skillBLock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quest currentQuest = RuntimeQuestData.GetCurrentQuest();
        if (currentQuest.Id == _questId)
        {
            if (_skillBLock != null)
            {
                _skillBLock.SetActive(true);
            }
        }
    }
}
