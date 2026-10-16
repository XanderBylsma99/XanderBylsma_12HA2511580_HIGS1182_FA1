using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    public enum ObjectType
    {
        Enemy,
        Asteroid
    }

    public ObjectType objectType;

    private void OnDestroy()
    {
        if (EnemyManager.Instance == null)
            return;

        int points = 0;

        switch (objectType)
        {
            case ObjectType.Enemy:
                points = 2;
                break;

            case ObjectType.Asteroid:
                points = 1;
                break;
        }

        EnemyManager.Instance.AddPoints(points);
    }
}