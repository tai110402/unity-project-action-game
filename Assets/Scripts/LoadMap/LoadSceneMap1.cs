using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneMap1 : MonoBehaviour
{
    [SerializeField] SaveLoadSystem _saveLoadSystem;
    private void OnTriggerEnter(Collider other)
    {
        _saveLoadSystem.SaveData(true);
        SceneManager.LoadScene(1);
    }
}
