using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ColorCategory;

public class TraditionalColor : MonoBehaviour
{
    private ColorData colorData;

    [SerializeField]
    private Text tmp;

    public void Awake()
    {
        White();
    }

    public void Change(TraditionalColor c)
    {
        Change(c.GetColorData());
    }

    public void Change(ColorData c)
    {
        colorData = c;
        Init();
    }

    private void Init()
    {
        var a = GetComponent<Image>();
        Color b = new Color(0, 0, 0);
        ColorUtility.TryParseHtmlString(colorData.colorCode, out b);
        a.color = b;
        if (tmp != null)
        {
            tmp.text = colorData.colorName;
        }
    }

    public void White()
    {
        colorData = new ColorData("白", EColorCategory.red, "#FFFFFF", "しろ");
        Init();
    }

    public ColorData GetColorData()
    {
        return colorData;
    }

    public string GetColorName()
    {
        return colorData.colorName;
    }

    public EColorCategory GetColorCategory()
    {
        return colorData.colorCategory;
    }

    public string GetColorCode()
    {
        return colorData.colorCode;
    }

    public string GetDerivation()
    {
        return colorData.derivation;
    }

    public bool Equals(TraditionalColor c)
    {
        return GetColorCode().Equals(c.GetColorCode());
    }

    public void Print()
    {
        Debug.Log(colorData.colorName);
    }

    public void Select()
    {
        transform.parent.parent.GetComponent<GameManager>().Select(this);
    }
}
