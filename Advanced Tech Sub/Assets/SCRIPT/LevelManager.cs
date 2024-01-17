using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LevelManager : MonoBehaviour
{
    public int appleCount;
    public TMP_Text Counter;

    private void Update()
    {
        Counter.text = "- " + appleCount;
    }
}
