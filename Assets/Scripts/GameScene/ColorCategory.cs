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
            // if header
            if (i == 0)
            {
                continue;
            }

            string[] color = colors[i].Split(",");
            string colorCategoryStr = color[0].Replace("\"", "");
            EColorCategory category = EColorCategory.none;

            if (!TryParse(colorCategoryStr, out category))
            {
                Debug.Log("category cannot parse EColorCategory on:\n" + colors[i]);
                continue;
            }

            if (!category.Equals(e))
            {
                Debug.Log("not selected category");
                continue;
            }

            string[] colorNames = color[1].Replace("\"", "").Split("（");
            string colorName = colorNames[0];
            string colorCode = color[3];
            string colorRubi = colorNames[1].Substring(0, colorNames[1].Length - 1);
            // 説明文の冒頭に，「名前（ふりがな）」がテンプレートとして記述されている. 
            string description = color[4];
            // string description = "rubi**" + colorRubi + "**" + color[4];
            // Debug.Log("rubi: " + description);

            colorList.Add(new ColorData(colorName, category, colorCode, description, colorRubi));
        }

        Debug.Log("list item count: " + colorList.Count);
        foreach (var item in colorList)
        {
            Debug.Log("rubi: " + item.colorNameRubi);
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
