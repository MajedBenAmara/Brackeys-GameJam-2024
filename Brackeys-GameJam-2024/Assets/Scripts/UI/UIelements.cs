using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIelements : MonoBehaviour
{
    [SerializeField] GameObject Shop;
    bool isEnabled;

    private void Start()
    {
        isEnabled = false;
    }
    void Update()
    {
        Time.timeScale = (!isEnabled ? 1.0f : 0.0f);
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEnabled = !isEnabled;
            Shop.SetActive(isEnabled);
        }
    }
}
