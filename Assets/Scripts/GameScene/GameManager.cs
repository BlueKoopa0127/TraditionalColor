using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ColorCategory;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //色のカテゴリを前のシーンから受け取る
        EColorCategory e = EColorCategory.red;
        var category = new ColorCategory(e);

        //カテゴリ内から色を10色ランダムに選択する
        var choiceColor = category.RandomChoice(10);

        //その中から答えを生成する
        //todo choiceColorの上から4つを選ぶ
        //todo choiceColorをランダムに入れ替える
        var answerList = new List<TraditionalColor>();        
    }

    // Update is called once per frame
    void Update()
    {
        //ユーザーが答えを当てる
        //正誤判定を行う
        //ユーザーからアクションがあれば
        //Judge(入力);

        //結果を返す
        //UIで表示

        //合っていたら終了
        //Finish();
    }
}
