using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutOption : MonoBehaviour
{
    [SerializeField]
    private int col, row, padding;
    // Start is called before the first frame update
    void Start()
    {
        // GridLayoutGroup grid = GetComponent<GridLayoutGroup>();
        // var width = (float)GetMainGameViewSize().x;
        // var val = (int)Mathf.Round(width * widthPercentage);
        // grid.cellSize = new Vector2(val, val);
        var cellSize = this.transform.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize;
        var widthSize = this.GetComponent<RectTransform>().sizeDelta.x / col / 3;
        var heightSize = this.GetComponent<RectTransform>().sizeDelta.y / row / 3;
        var size = Math.Min(widthSize, heightSize);
        cellSize = new Vector2(size - padding, size - padding);
        this.transform.GetComponent<UnityEngine.UI.GridLayoutGroup>().cellSize = cellSize;

        var spacing = this.transform.GetComponent<UnityEngine.UI.GridLayoutGroup>().spacing;
        spacing = new Vector2(size * 3, size * 3);
        this.transform.GetComponent<UnityEngine.UI.GridLayoutGroup>().spacing = spacing;

        // Update is called once per frame
        void Update()
        {

        }
    }
}