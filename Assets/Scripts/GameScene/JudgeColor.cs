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
  
  public JudgeColor(List<TraditionalColor> answer){
    this.answer = answer;
  }

  public List<int> CheckHitAndBlow(List<TraditionalColor> userPredict){
    // [0]HIT, [1]BLOW
    List<int> result = new List<int>(2){0,0};
    for (int i = 0; i < userPredict.Count; i++)
    {
      Debug.Log("start " + i + ":: " + userPredict[i]);
      // 予想した色に対応した答えの場所      
      int ansId = answer.FindIndex(item => item.Equals(userPredict[i]));

      Debug.Log("miss?");
      if (ansId < 0)
      {
        continue;
      }

      // HIT
      if (ansId == i){
        result[0] += 1;
        continue;
      }

      // BLOW
      result[1] += 1;
    }

    return result;
  }
}
