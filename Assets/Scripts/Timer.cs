using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private int timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        timer.text = timeLimit.ToString();
        StartCoroutine(startTimerCo());
    }

    IEnumerator startTimerCo()
    {
        int currentTime = timeLimit;

        while (currentTime >= 0)
        {
            timer.text = currentTime.ToString(); // 텍스트 업데이트
            yield return new WaitForSeconds(1f); // 1초 대기
            currentTime--; // 시간 감소
        }

        // 타이머 종료 후 추가 동작이 필요하다면 여기에 추가
        Debug.Log("Timer finished!");
    }
}
