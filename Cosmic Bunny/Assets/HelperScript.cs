using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private float score;

    void Start()
    {
        score = 0;
        scoreText.text = "- " + score.ToString() + " -";
    }

    [SerializeField] Camera cam;

    public bool IsVisibleToCamera(Vector3 target)
    {
        Vector3 target_pos = cam.WorldToViewportPoint(target);
        if (target_pos.y < 0 || target_pos.y > 1)
        {
            return false; //jest poza kamera
        }
        else
        {
            return true; //jest widoczny dla kamery
        }
    }

    public void UpdateScore(int amount)
    {
        this.score += amount;
        scoreText.text = "- " + score.ToString() + " -";
    }
}
