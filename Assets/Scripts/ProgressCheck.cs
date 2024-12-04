using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityProgressBar;

public class ProgressCheck : MonoBehaviour
{
    [SerializeField] private ProgressBar feedBar;
    [SerializeField] private ProgressBar greetBar;
    [SerializeField] private ProgressBar catchBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckProgress();
        CheckCatchProgress();
    }

    private void CheckProgress()
    {
        if (feedBar == null && greetBar == null) return;
        if (feedBar.Value>=1 && greetBar.Value>=1)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void CheckCatchProgress()
    {
        if (catchBar == null) return;
        if (catchBar.Value>=1)
        {
            StartCoroutine(WaitUntilDeath());
        }
    }
    
    IEnumerator WaitUntilDeath()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(5);
    }
}
