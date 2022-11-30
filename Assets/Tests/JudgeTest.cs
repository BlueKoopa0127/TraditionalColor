// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using NUnit.Framework;
// using UnityEngine.TestTools;
// using static ColorCategory;

// public class JudgeTest : MonoBehaviour
// {
//     [Test]
//     [
//         TestCase(
//             new List<TraditionalColor>(new TraditionalColor("赤"), new TraditionalColor("緑"), new TraditionalColor("白")),
//             new List<TraditionalColor>(new TraditionalColor("緑"), new TraditionalColor("赤"), new TraditionalColor("白")),
//             (1, 1)
//         )
//     ]
//     public void TestGet(List<TraditionalColor> t, List<TraditionalColor> ansT, (int, int) answer)
//     {
//         Judge j = new Judge(ansT);
//         Assert.That(j.Judge(t), Is.EqualTo(answer));
//     }
// }
