using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class LocalizationYG : MonoBehaviour
{
    [SerializeField] private string _ru;
    [SerializeField] private string _en;

    private void Start()
    {
        if (YandexGame.savesData.language == "ru")
        {
            GetComponent<TMP_Text>().text = _ru;
        }
        else
        {
            GetComponent<TMP_Text>().text = _en;
        }
    }
}
