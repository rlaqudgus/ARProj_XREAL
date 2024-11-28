using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProgressBar;

public class FeedButton : MonoBehaviour
{
    [SerializeField] ProgressBar feedBar;

    public void FeedAnimal()
    {
        feedBar.Value += 0.2f;
    }
}
