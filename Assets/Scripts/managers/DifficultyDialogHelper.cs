using UnityEngine;

public class DifficultyDialogHelper : MonoBehaviour
{
    public void SetDifficultyEasy()  => DifficultySettings.Difficulty = 0;
    public void SetDifficultyNormal() => DifficultySettings.Difficulty = 1;
    public void SetDifficultyHard()  => DifficultySettings.Difficulty = 2;
    public void SetDifficultyInsane()  => DifficultySettings.Difficulty = 3;
}