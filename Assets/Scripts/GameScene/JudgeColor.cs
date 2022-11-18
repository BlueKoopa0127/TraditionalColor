using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeColor
{
  private List<TraditionalColor> answer;
  // TODO 判断結果のリストの型，新しくenumのやつで作ってもいいかも
  private List<string> result;

  JudgeColor(List<TraditionalColor> answer){
    this.answer = answer;
    this.result = new List<string>();
  }

}
