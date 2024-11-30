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
            timer.text = currentTime.ToString(); // �ؽ�Ʈ ������Ʈ
            yield return new WaitForSeconds(1f); // 1�� ���
            currentTime--; // �ð� ����
        }

        // Ÿ�̸� ���� �� �߰� ������ �ʿ��ϴٸ� ���⿡ �߰�
        Debug.Log("Timer finished!");
    }
}
