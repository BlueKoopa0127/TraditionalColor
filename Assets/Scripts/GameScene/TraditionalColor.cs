using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ColorCategory;

public class TraditionalColor : MonoBehaviour
{
    [SerializeField]
    private string colorName;
    [SerializeField]
    private EColorCategory colorCategory;
    [SerializeField]
    private string colorCode;
    [SerializeField]
    private string derivation;

    public void Awake()
    {
        Init();
    }

    public TraditionalColor(string cn = "赤", EColorCategory cc = EColorCategory.red, string cCode = "#ff0000", string d = "")
    {
        colorName = cn;
        colorCategory = cc;
        colorCode = cCode;
        derivation = d;
    }

    public void Change(TraditionalColor t)
    {
        colorName = t.GetColorName();
        colorCategory = t.GetColorCategory();
        colorCode = t.GetColorCode();
        derivation = t.GetDerivation();
        Init();
    }

    private void Init()
    {
        var a = GetComponent<Image>();
        Color b = new Color(0, 0, 0);
        ColorUtility.TryParseHtmlString(colorCode, out b);
        a.color = b;
    }

    public void White()
    {
        colorName = "白";
        colorCategory = EColorCategory.red;
        colorCode = "#FFFFFF";
        derivation = "しろ";
        Init();
    }

    public string GetColorName()
    {
        return colorName;
    }

    public EColorCategory GetColorCategory()
    {
        return colorCategory;
    }

    public string GetColorCode()
    {
        return colorCode;
    }

    public string GetDerivation()
    {
        return derivation;
    }

    public bool Equals(TraditionalColor c)
    {
        return GetColorCode().Equals(c.GetColorCode());
    }

    public void Print()
    {
        Debug.Log(colorName);
    }

    public void Select()
    {
        transform.parent.parent.GetComponent<GameManager>().Select(this);
    }
}
