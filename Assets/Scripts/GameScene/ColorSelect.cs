using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;
using System;
using UnityEngine.UI;

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


            var (text, color) = Translate(Value);
            b.transform.GetChild(0).GetComponent<Text>().text = text;

            var i = b.GetComponent<Image>();
            Color c = new Color(0, 0, 0);
            ColorUtility.TryParseHtmlString(color, out c);
            i.color = c;


            var button = b.GetComponent<Button>();
            button.onClick.AddListener(() => gameManager.SetActive(true));
            button.onClick.AddListener(() => gameManager.GetComponent<GameManager>().Init(Value));
            button.onClick.AddListener(() => gameObject.SetActive(false));

        }
    }

    private (String, String) Translate(EColorCategory e)
    {
        switch (e)
        {
            case EColorCategory.achromatic:
                return ("白黒系統", "#c8c2be");
            case EColorCategory.blue:
                return ("青系統", "#0086CC");
            case EColorCategory.brown:
                return ("茶系統", "#612E04");
            case EColorCategory.green:
                return ("緑系統", "#00a381");
            case EColorCategory.red:
                return ("赤系統", "#E2421F");
            case EColorCategory.violet:
                return ("紫系統", "#5F414B");
            case EColorCategory.yellow:
                return ("黄系統", "#ECE038");
            default:
                return ("", "");
        }
    }
}
