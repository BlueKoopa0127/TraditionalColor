using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;

public class GameManager : MonoBehaviour
{
    // Q: こいつらグローバルでいいのか？
    private List<TraditionalColor> userPredict = new List<TraditionalColor>();
    private JudgeColor judge;
    [SerializeField]
    private Transform select, selected, answer;

    private int count = 0;

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
        for (int i = 0; i < 10; i++)
        {
            select.GetChild(i).GetComponent<TraditionalColor>().Change(choiceColor[i]);
        }

        // 選択された色のインスタンスの登録
        for (int i = 0; i < 4; i++)
        {
            var t = selected.GetChild(i).GetComponent<TraditionalColor>();
            userPredict.Add(t);
        }

        //その中から答えを生成する
        var ans = makeAnswer(choiceColor, 4);
        for (int i = 0; i < 4; i++)
        {
            answer.GetChild(i).GetComponent<TraditionalColor>().Change(ans[i]);
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
        if (count == 4)
        {
            var result = judge.checkHitAndBlow(userPredict);

            Debug.Log("Hit : " + result[0] + " Brow : " + result[1]);

            count = 0;
            for (int i = 0; i < 4; i++)
            {
                selected.GetChild(i).GetComponent<TraditionalColor>().White();
            }
        }
        // UIで表示
        // 合っていたら終了
        // Finish();
    }

    private List<TraditionalColor> makeAnswer(List<TraditionalColor> choiceColor, int answerLength)
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
