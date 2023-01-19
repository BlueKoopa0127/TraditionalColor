using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUpdate : MonoBehaviour
{
    private int defaultWindowHeight;
    // Start is called before the first frame update
    void Start()
    {
        defaultWindowHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (defaultWindowHeight != Screen.height)
        {
            var selectPosition = this.transform.position;
            selectPosition.y = Screen.height / 6;
            this.transform.position = selectPosition;
        }
    }
}
