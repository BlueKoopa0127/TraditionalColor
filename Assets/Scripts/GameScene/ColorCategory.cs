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

    private List<TraditionalColor> colorList;

    public ColorCategory(EColorCategory e) {
        //todo eによってファイルを読んでそのカテゴリのTraditionalColorのリストを取得してcolorListに格納する。
        // スクレイピング待ちではある
        var carmine = new TraditionalColor("洋紅色", EColorCategory.red, "#DA003D", "ようこうしょく");
        var benitou = new TraditionalColor("紅唐", EColorCategory.red, "#D45750", "べにとう");
        var ginshu = new TraditionalColor("銀朱", EColorCategory.red, "#E24215", "ぎんしゅ");
        var kobai = new TraditionalColor("紅梅色", EColorCategory.red, "#E86B79", "こうばいいろ");
        var beniaka = new TraditionalColor("紅赤", EColorCategory.red, "#E5004F", "べにあか");
        var sinku = new TraditionalColor("真紅", EColorCategory.red, "#AD002D", "しんく");
        var enji = new TraditionalColor("臙脂色", EColorCategory.red, "#9B003F", "えんじいろ");
        var zakuro = new TraditionalColor("柘榴色", EColorCategory.red, "#C92E36", "ざくろいろ");
        var shinshu = new TraditionalColor("真朱", EColorCategory.red, "#D9341D", "しんしゅ");
        var sangoshu = new TraditionalColor("珊瑚珠色", EColorCategory.red, "#EF454A", "さんごしゅいろ");

        colorList = new List<TraditionalColor>(){carmine, benitou, ginshu, kobai, beniaka, sinku, enji, zakuro, sinku, sangoshu};
    }


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
