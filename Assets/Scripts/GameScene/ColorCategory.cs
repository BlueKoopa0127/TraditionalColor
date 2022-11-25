using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCategory
{
    public enum EColorCategory
    {
        // Noneが欲しいかも
        red, brown, green
    }

    public ColorCategory(EColorCategory e) {
        //todo eによってファイルを読んでそのカテゴリのTraditionalColorのリストを取得してcolorListに格納する。
        // スクレイピング待ちではある
    }

    private List<TraditionalColor> colorList = new List<TraditionalColor>();

    public List<TraditionalColor> RandomChoice(int n) {
        // todo colorListをランダムシャッフルしてn番目までを返す
        for(int i = colorList.Count -1;i>0;i--){
            //乱数生成を使ってランダムに取り出す値を決める 
            int r = UnityEngine.Random.Range(0, i+1);
            //取り出した値と箱の外の先頭の値を交換する
            var tmp = colorList[i];
            colorList[i] = colorList[r];
            colorList[r] = tmp;
        }
        return colorList.GetRange(0,n);
    }
}
