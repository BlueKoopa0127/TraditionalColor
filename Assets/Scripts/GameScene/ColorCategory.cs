using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCategory
{
    public enum EColorCategory
    {
        red, brown, green
    }

    public ColorCategory(EColorCategory e) {
        //todo eによってファイルを読んでそのカテゴリのTraditionalColorのリストを取得してcolorListに格納する。
        // スクレイピング待ちではある
    }

    private List<TraditionalColor> colorList = new List<TraditionalColor>();

    public List<TraditionalColor> RandomChoice(int n) {
        // todo colorListをランダムシャッフルしてn番目までを返す
        return null;
    }
}
