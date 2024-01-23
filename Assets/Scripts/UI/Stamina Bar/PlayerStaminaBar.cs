using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaBar : MonoBehaviour
{
    [SerializeField] private Image _playerStaminaBarImage;
    [SerializeField] private float _imageWidth = 350f;
    [SerializeField] private float _imageHeight = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int currentStamina = RuntimePlayerData.PlayerData.CurrentStamina;
        int maxStamina = RuntimePlayerData.PlayerData.MaxStamina;
        float currentImageWidth = _imageWidth * currentStamina / maxStamina;
        _playerStaminaBarImage.rectTransform.sizeDelta = new Vector2(currentImageWidth, _imageHeight);
    }
}
