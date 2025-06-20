using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public int score = 0; 

    public void AddScore(int points)
    {
        
        score += points;

        
        Debug.Log("Score bijgewerkt: " + score);
    }
}
