using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBottleController : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] GameObject _UILootHP;

    private float _distance = 5f;
    private Vector3 _rayOrigin;
    RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rayOrigin = _cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(_rayOrigin, _cam.transform.forward, out _hit, _distance))
        {
            if (_hit.collider.gameObject.CompareTag("HPBottle"))
            {
                _UILootHP.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    RuntimePlayerData.PlayerData.HPBottles += 1;
                    GameObject.Destroy(_hit.collider.gameObject);
                }
            } else
            {
                _UILootHP.SetActive(false);
            }
        } else
        {
            _UILootHP.SetActive(false);
        }
    }
}
