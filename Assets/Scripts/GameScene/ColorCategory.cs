using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCategory
{
    public enum EColorCategory
    {
        none = 0, brown, blue, yellow, achromatic, green, red, violet
    }

    private List<ColorData> colorList;

    public ColorCategory(EColorCategory e)
    {
        //todo eによってファイルを読んでそのカテゴリのTraditionalColorのリストを取得してcolorListに格納する。
        // スクレイピング待ちではある
        var carmine = new ColorData("洋紅色", EColorCategory.red, "#DA003D", "ようこうしょく");
        var benitou = new ColorData("紅唐", EColorCategory.red, "#D45750", "べにとう");
        var ginshu = new ColorData("銀朱", EColorCategory.red, "#E24215", "ぎんしゅ");
        var kobai = new ColorData("紅梅色", EColorCategory.red, "#E86B79", "こうばいいろ");
        var beniaka = new ColorData("紅赤", EColorCategory.red, "#E5004F", "べにあか");
        var sinku = new ColorData("真紅", EColorCategory.red, "#AD002D", "しんく");
        var enji = new ColorData("臙脂色", EColorCategory.red, "#9B003F", "えんじいろ");
        var zakuro = new ColorData("柘榴色", EColorCategory.red, "#C92E36", "ざくろいろ");
        var shinshu = new ColorData("真朱", EColorCategory.red, "#D9341D", "しんしゅ");
        var sangoshu = new ColorData("珊瑚珠色", EColorCategory.red, "#EF454A", "さんごしゅいろ");

        colorList = new List<ColorData>() { carmine, benitou, ginshu, kobai, beniaka, sinku, enji, zakuro, shinshu, sangoshu };

        string currentDirPath = Environment.CurrentDirectory;
        string relativePathFromcurrentDir = @"./Assets/Data/TraditionalColors.csv";
        string csvFileFullPath = Path.GetFullPath(relativePathFromcurrentDir, currentDirPath);

        // This text is added only once to the file.
        if (!File.Exists(csvFileFullPath))
        {
            throw new FileNotFoundException("such file is not found\nPath: " + csvFileFullPath);
        }

        Debug.Log("csv file found");
        colorList = new List<ColorData>();


        string[] colors = File.ReadAllLines(csvFileFullPath);
        for (int i = 0; i < colors.Length; i++)
        {
            if (i == 0)
            {
                continue;
            }
            // "category","name","url","colorcode","description"
            string[] color = colors[i].Split(",");
            string colorName = color[1].Split("（")[0];
            string colorCode = color[3];
            string description = color[4];

            string colorCategoryStr = color[0].Replace("\"", "");
            EColorCategory category = EColorCategory.none;
            if (TryParse(colorCategoryStr, out category))
            {
                colorList.Add(new ColorData(colorName, category, colorCode, description));
            }
            else
            {
                Debug.Log("category cannot parse EColorCategory on:\n" + colors[i]);
            }
        }
    }


    public List<ColorData> RandomChoice(int n)
    {
        // todo colorListをランダムシャッフルしてn番目までを返す
        for (int i = colorList.Count - 1; i > 0; i--)
        {
            //乱数生成を使ってランダムに取り出す値を決める 
            int r = UnityEngine.Random.Range(0, i + 1);
            //取り出した値と箱の外の先頭の値を交換する
            var tmp = colorList[i];
            colorList[i] = colorList[r];
            colorList[r] = tmp;
        }
        return colorList.GetRange(0, n);
    }

    private bool TryParse(string s, out EColorCategory category)
    {
        return Enum.TryParse(s, out category) && Enum.IsDefined(typeof(EColorCategory), category);

    }
}
