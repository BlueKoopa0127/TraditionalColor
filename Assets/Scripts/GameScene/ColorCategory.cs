using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCategory
{
    public enum EColorCategory
    {
        brown, blue, yellow, achromatic, green, red, violet
    }

    private List<ColorData> colorList;

    private TextAsset csvFile;

    public ColorCategory(EColorCategory e)
    {
        colorList = new List<ColorData>();

        csvFile = Resources.Load("TraditionalColors") as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() != -1)
        {
            string[] color = reader.ReadLine().Split(",");
            string colorCategoryStr = color[0].Replace("\"", "");
            EColorCategory category = EColorCategory.red;

            if (!TryParse(colorCategoryStr, out category))
            {
                Debug.Log("category cannot parse EColorCategory on:");
                continue;
            }

            if (!category.Equals(e))
            {
                Debug.Log("not selected category");
                continue;
            }

            string[] colorNames = color[1].Replace("\"", "").Split("（");
            string colorName = colorNames[0].Replace("\"", "");
            string colorCode = color[3].Replace("\"", "");
            string colorRubi = colorNames[1].Substring(0, colorNames[1].Length - 1);
            // 説明文の冒頭に，「名前（ふりがな）」がテンプレートとして記述されている. 
            string description = color[4].Replace("\"", "");
            // string description = "rubi**" + colorRubi + "**" + color[4];
            // Debug.Log("rubi: " + description);

            colorList.Add(new ColorData(colorName, category, colorCode, description));
        }

        Debug.Log("list item count: " + colorList.Count);
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
