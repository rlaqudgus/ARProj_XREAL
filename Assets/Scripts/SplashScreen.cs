using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Image loadingBar; // 로딩 바 이미지
    [SerializeField] private RectTransform circle; // 이동할 Circle 이미지 (RectTransform)
    private float splashDuration = 20f; // 스플래시 화면 지속 시간

    void Start()
    {
        // 프로그레스바 채우기
        if (loadingBar != null)
        {
            loadingBar.fillAmount = 0f; // 초기 상태
            loadingBar.DOFillAmount(1f, splashDuration).SetEase(Ease.Linear); // 1까지 채우기
        }

        // Circle 이미지 이동
        if (circle != null)
        {
            MoveCircle();
        }

        // Splash 종료 후 씬 이동
        DOVirtual.DelayedCall(splashDuration, EndSplashScreen);
    }

    void MoveCircle()
    {
        // 현재 위치: right 90%
        Vector2 startAnchor = new Vector2(0.9f, circle.anchorMin.y); // anchorMin 기준
        circle.anchorMin = startAnchor;
        circle.anchorMax = startAnchor;

        // 목표 위치: left 90%
        Vector2 targetAnchor = new Vector2(0.1f, circle.anchorMin.y); // left 90%

        // DOTween으로 anchorMin과 anchorMax 이동
        circle.DOAnchorMin(targetAnchor, splashDuration).SetEase(Ease.OutQuad);
        circle.DOAnchorMax(targetAnchor, splashDuration).SetEase(Ease.OutQuad);
    }

    void EndSplashScreen()
    {
        SceneManager.LoadScene("MainScene"); // 다음 씬으로 이동
    }
}
