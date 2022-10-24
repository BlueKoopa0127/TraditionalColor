using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;

public class TraditionalColor
{
    private readonly string colorName;
    private readonly EColorCategory colorCategory;
    private readonly string colorCode;
    private readonly string derivation;

    public TraditionalColor(string cn = "赤", EColorCategory cc = EColorCategory.red, string cCode = "#ff0000", string d = "")
    {
        colorName = cn;
        colorCategory = cc;
        colorCode = cCode;
        derivation = d;
    }

    public string GetColorName()
    {
        return colorName;
    }

    public EColorCategory GetColorCategory()
    {
        return EColorCategory.red;
    }

    public string GetColorCode()
    {
        return "";
    }

    public string GetDerivation()
    {
        return "";
    }
}
