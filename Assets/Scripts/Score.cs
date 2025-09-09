using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    
    public void AddScore()
    {
        int CurrentScore = int.Parse(score.text);
        score.text = (CurrentScore+1).ToString();
    }
}
