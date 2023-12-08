using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using GoogleMobileAds.Api;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject gameOverPanel; // Reference to your game-over panel
    private float startTime;
    private bool timerActive = true;
    public AudioClip coinCollectSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time + 30f;
        gameOverPanel.SetActive(false); // Initially hide the game-over panel
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            float t = startTime - Time.time;

            if (t <= 0)
            {
                t = 0;
                timerActive = false; // Stop the timer
                ShowGameOver();
                Interstitial.Instance.ShowAd();
            }

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");

            timerText.text = minutes + ":" + seconds;
        }
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            startTime += 10f; // Add 10 seconds to the timer
            Destroy(other.gameObject);
            ScoreManager.scoreCount += 1;
            if (coinCollectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinCollectSound); // Play the coin collection sound
            }
        }
    }

    // Show the game-over panel and perform any other game-over actions
    void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        // You can add any additional game-over actions here.
    }

    // Method to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene("Game Scene");
        ScoreManager.scoreCount = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
