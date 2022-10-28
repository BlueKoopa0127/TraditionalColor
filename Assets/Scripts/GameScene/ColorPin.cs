using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPin
{
  private readonly EColorCategory colorCategory;
  private readonly int placeID;

  public ColorPin(EColorCategory cc = EColorCategory.red, int id = -1){
    if(id < 0){
      // エラーを投げたい気がする
    }
  }
}
