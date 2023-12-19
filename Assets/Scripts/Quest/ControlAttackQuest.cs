using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAttackQuest : MonoBehaviour
{
    [SerializeField] private string _questId = "002";
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private float _minDistanceRenderArrow = 8;
    private bool _isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Quest currentQuest = RuntimeQuestData.GetCurrentQuest();

        if (currentQuest.Id == _questId && _isActive == false)
        {
            _isActive = true;
            foreach (GameObject enemy in _enemies)
            {
                enemy.SetActive(true);
            }

        }

        float distance = Vector3.Magnitude(player.transform.position - currentQuest.Position);
        
        if (currentQuest.Type == "attack")
        {
            if (distance > _minDistanceRenderArrow)
            {
                Arrow.SetArrow = true;
            }
            else
            {
                Arrow.SetArrow = false;
            }
        }
    }
}
