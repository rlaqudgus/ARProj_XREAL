using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProgressBar;

public class GreetButton : MonoBehaviour
{
    [SerializeField] ProgressBar greetBar;

    public void GreetAniaml()
    {
        greetBar.Value += 0.2f;
    }
}
