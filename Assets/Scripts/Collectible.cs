using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    // A reference to your score text GameObject
    public Text score;
    // How much this particular collectible is worth (score)
    public int scoreAmount;

    // OnTriggerEnter2D instead of OnCollider2D because we checked "Is Trigger"
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Get the current score
            int newScore = Int32.Parse(score.text) + scoreAmount;
            // Save the current score to be used across multiple scenes.
            PlayerPrefs.SetInt("score", newScore);
            // Display the newScore in the UI
            score.text = newScore.ToString();
            // Make the Collectible disappear
            Destroy(gameObject);
        }
        if (score.text == "10") {
            SceneManager.LoadScene("WinScreen");
        }
    }
}