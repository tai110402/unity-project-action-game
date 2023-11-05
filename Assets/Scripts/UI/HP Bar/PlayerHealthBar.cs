using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _playerHPBarImage;
    [SerializeField] private float _imageWidth = 350f;
    [SerializeField] private float _imageHeight = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentHP = RuntimePlayerData.PlayerData.CurrentHP;
        int maxHP = RuntimePlayerData.PlayerData.MaxHP;
        float currentImageWidth = _imageWidth * currentHP / maxHP;
        _playerHPBarImage.rectTransform.sizeDelta = new Vector2(currentImageWidth, _imageHeight);
    }
}
