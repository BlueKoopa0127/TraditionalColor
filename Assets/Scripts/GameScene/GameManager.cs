using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;

public class GameManager : MonoBehaviour
{
    // Q: こいつらグローバルでいいのか？
    private List<TraditionalColor> userPredict = new List<TraditionalColor>();
    private JudgeColor judge;

    // Start is called before the first frame update
    void Start()
    {
        //色のカテゴリを前のシーンから受け取る
        EColorCategory e = EColorCategory.red;
        var category = new ColorCategory(e);

        //カテゴリ内から色を10色ランダムに選択する
        var choiceColor = category.RandomChoice(10);
        //その中から答えを生成する
        var answer = MakeAnswer(choiceColor, 4);
        // Q: makeAnserを直接入れてもいいのか？
        judge = new JudgeColor(answer);
    }

    // Update is called once per frame
    void Update()
    {
        //ユーザーが答えを当てる
        
        // もしユーザーが予想の確定をしていないなら何もしない
        // continue? return?

        // ユーザーの入力の受け取り
        // TODO: userPredict = getUserPredict()的なやつ
        userPredict = new List<TraditionalColor>();

        // 正誤判定を行う
        // Judge.checkHitandBlow(入力);
        // 結果を返す
        var result = judge.checkHitAndBlow(userPredict);

        // UIで表示
        // 合っていたら終了
        // Finish();
    }

    private List<TraditionalColor> MakeAnswer(List<TraditionalColor> choiceColor, int answerLength)
    {
        for(int i = choiceColor.Count -1;i>0;i--){
            //乱数生成を使ってランダムに取り出す値を決める 
            int r = UnityEngine.Random.Range(0,i+1);
            //取り出した値と箱の外の先頭の値を交換する
            var tmp = choiceColor[i];
            choiceColor[i] = choiceColor[r];
            choiceColor[r] = tmp;
        }

        return choiceColor.GetRange(0,answerLength);
    }
}
