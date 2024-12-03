using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private Image displayImage; 
    [SerializeField] private Sprite[] images;   
    private float imageDisplayTime = 0.5f;      
    private float splashDuration = 2f;         
    private int currentImageIndex = 0;         
    private float timer = 0f;                 

    void Start()
    {
        if (images.Length > 0)
        {
            displayImage.sprite = images[0]; 
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= imageDisplayTime && currentImageIndex < images.Length - 1)
        {
            currentImageIndex++;
            displayImage.sprite = images[currentImageIndex];
            timer = 0f; 
        }

        if (timer >= splashDuration)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
