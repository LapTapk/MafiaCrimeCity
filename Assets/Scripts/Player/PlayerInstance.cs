using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
    public static PlayerInstance Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            throw new UnityException("PlayerGameObject component must have only one instance");
        else
            Instance = this;
    }
}
