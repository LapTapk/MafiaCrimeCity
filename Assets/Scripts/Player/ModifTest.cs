using UnityEngine;

public class ModifTest : MonoBehaviour
{
    private void Start()
    {
        PlayerInstance.Instance.gameObject.GetComponent<PlayerMovement>().Modifier.Add(() => 0.5f, 4);
    }    
}
