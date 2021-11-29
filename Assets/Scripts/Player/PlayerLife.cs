using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : CharacterLife
{
    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
