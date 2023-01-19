using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;
using System;
using UnityEngine.UI;
using TMPro;

public class ColorSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject colorSelectButton, gameManager;
    void Start()
    {
        foreach (EColorCategory Value in Enum.GetValues(typeof(EColorCategory)))
        {
            string name = Enum.GetName(typeof(EColorCategory), Value);

            // オブジェクト生成
            var b = Instantiate(colorSelectButton);
            b.transform.SetParent(transform.GetChild(0), false);

            b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = name;

            var button = b.GetComponent<Button>();
            button.onClick.AddListener(() => gameObject.SetActive(false));
            button.onClick.AddListener(() => gameManager.SetActive(true));
            button.onClick.AddListener(() => gameManager.SetActive(true));

        }
    }
}
