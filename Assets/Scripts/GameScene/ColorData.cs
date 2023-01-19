using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;

public struct ColorData
{
    public string colorName { get; private set; }
    public EColorCategory colorCategory { get; private set; }
    public string colorCode { get; private set; }
    public string derivation { get; private set; }

    public ColorData(string cn = "赤", EColorCategory cc = EColorCategory.red, string cCode = "#ff0000", string d = "")
    {
        colorName = cn;
        colorCategory = cc;
        colorCode = cCode;
        derivation = d;
    }
}
