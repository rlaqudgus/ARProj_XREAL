using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityProgressBar;

public class ProgressCheck : MonoBehaviour
{
    [SerializeField] private ProgressBar feedBar;
    [SerializeField] private ProgressBar greetBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckProgress();
    }

    private void CheckProgress()
    {
        if(feedBar.Value>=1 && greetBar.Value>=1)
        {
            SceneManager.LoadScene(2);
        }
    }
}
