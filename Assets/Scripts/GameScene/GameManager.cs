using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject selectColor, selectedColor, answerColor;

    // Q: こいつらグローバルでいいのか？
    private List<TraditionalColor> userPredict = new List<TraditionalColor>();

    private List<List<TraditionalColor>> userHistory = new List<List<TraditionalColor>>();
    private JudgeColor judge;
    [SerializeField]
    private Transform select, selected, answer, history, historyAns, end;

    private int count = 0;
    private int rawCount = 0;
    private const int numberOfAns = 3, numberOfHistory = 4;
    private int histCount = 0;

    public void Select(TraditionalColor t)
    {
        selected.GetChild(count).GetComponent<TraditionalColor>().Change(t);
        count++;
    }

    // Start is called before the first frame update
    void Start()
    {
        //色のカテゴリを前のシーンから受け取る
        EColorCategory e = EColorCategory.red;
        var category = new ColorCategory(e);

        //カテゴリ内から色を10色ランダムに選択する
        var choiceColor = category.RandomChoice(10);
        foreach (var v in choiceColor)
        {
            var c = Instantiate(selectColor).GetComponent<TraditionalColor>();
            c.transform.parent = select;
            c.Change(v);
        }

        // 選択された色のインスタンスの登録
        for (int i = 0; i < numberOfAns; i++)
        {
            var t = Instantiate(selectedColor).GetComponent<TraditionalColor>();
            t.transform.parent = selected;
            userPredict.Add(t);
        }

        //その中から答えを生成する
        var ans = makeAnswer(choiceColor, numberOfAns);
        foreach (var a in ans)
        {
            var t = Instantiate(answerColor).GetComponent<TraditionalColor>();
            t.transform.parent = answer;
            t.Change(a);
        }

        for (int i = 0; i < numberOfHistory; i++)
        {
            var a = history.GetChild(i);
            Debug.Log(a.GetComponent<RectTransform>().rect);
            for (int j = 0; j < numberOfAns; j++)
            {
                var t = Instantiate(selectedColor).transform;
                t.parent = a;
            }
        }

        // Q: makeAnserを直接入れてもいいのか？
        judge = new JudgeColor(ans);
    }

    // Update is called once per frame
    void Update()
    {
        //ユーザーが答えを当てる

        // もしユーザーが予想の確定をしていないなら何もしない
        // continue? return?

        // ユーザーの入力の受け取り
        // TODO: userPredict = getUserPredict()的なやつ
        // userPredict = new List<TraditionalColor>();

        // 正誤判定を行う
        // Judge.checkHitandBlow(入力);
        // 結果を返す
        if (count == numberOfAns)
        {


            var result = judge.checkHitAndBlow(userPredict);

            Debug.Log("Hit : " + result[0] + " Brow : " + result[1]);

            userHistory.Add(userPredict);

            count = 0;
            rawCount++;



            var hist = history.GetChild(histCount);
            var histText = historyAns.GetChild(histCount).GetComponent<TextMeshProUGUI>();
            histText.text = result[0].ToString() + "H" + result[1].ToString() + "B";
            for (int i = 0; i < numberOfAns; i++)
            {
                var se = selected.GetChild(i).GetComponent<TraditionalColor>();
                hist.GetChild(i).GetComponent<TraditionalColor>().Change(se.GetColorData());
                se.White();
            }
            histCount++;

            //ゲーム終了
            if (histCount == numberOfHistory)
            {
                for (int i = 0; i < numberOfAns; i++)
                {
                    answer.GetChild(i).GetComponent<Image>().enabled = true;
                }
                end.gameObject.SetActive(true);
                //this.gameObject.SetActive(false);
            }
        }
        // UIで表示
        // 合っていたら終了
        // Finish();
    }

    private List<ColorData> makeAnswer(List<ColorData> choiceColor, int answerLength)
    {
        for (int i = choiceColor.Count - 1; i > 0; i--)
        {
            //乱数生成を使ってランダムに取り出す値を決める 
            int r = UnityEngine.Random.Range(0, i + 1);
            //取り出した値と箱の外の先頭の値を交換する
            var tmp = choiceColor[i];
            choiceColor[i] = choiceColor[r];
            choiceColor[r] = tmp;
        }

        return choiceColor.GetRange(0, answerLength);
    }
}
