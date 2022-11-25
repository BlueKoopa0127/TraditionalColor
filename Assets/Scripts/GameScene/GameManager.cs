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
        // todo colorListをランダムシャッフルしてn番目までを返す
        //todo choiceColorをランダムに入れ替える
        for(int i = choiceColor.Count -1;i>0;i--){
            //乱数生成を使ってランダムに取り出す値を決める 
            int r = UnityEngine.Random.Range(0,i+1);
            //取り出した値と箱の外の先頭の値を交換する
            var tmp = choiceColor[i];
            choiceColor[i] = choiceColor[r];
            choiceColor[r] = tmp;
        }
        
        var answerList = choiceColor.GetRange(0,4);
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
