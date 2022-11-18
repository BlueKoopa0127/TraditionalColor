using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * あらかじめ与えられた答えとユーザーの予想を
 * checkHitAndBlowメソッドで比較する
 * 11/18段階では比較結果がListのstringで返している
 */
public class JudgeColor
{
  private List<TraditionalColor> answer;
  
  JudgeColor(List<TraditionalColor> answer){
    this.answer = answer;
  }

  public List<string> checkHitAndBlow(List<TraditionalColor> userPredict){
    // TODO 判断結果のリストの型，新しくenumのやつで作ってもいいかも
    List<string> result;
    for (int i = 0; i < userPredict.Length; i++)
    {
      // 予想した色に対応した答えの場所
      int ansId = answer.FindIndex(n => n == userPredict[i]);

      if (ansId < 0)
      {
        result.add("Miss");
        continue;
      }

      if (ansId == i){
        result.add("Hit");
        continue;
      }

      result.add("Blow");
    }

    return result;
  }
}
