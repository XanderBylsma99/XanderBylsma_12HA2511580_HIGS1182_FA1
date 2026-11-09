using UnityEngine;

public class ScoreOnDestroy : MonoBehaviour
{
    public int pointsWorth = 5;

    private bool scoreAwarded = false;

    private void OnDestroy()
    {
        if (!Application.isPlaying)
            return;

        if (scoreAwarded)
            return;

        scoreAwarded = true;

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(pointsWorth);
        }
    }
}