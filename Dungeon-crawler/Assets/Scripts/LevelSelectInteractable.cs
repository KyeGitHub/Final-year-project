using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectInteractable : Interactable
{
    public override void Interact()
    {
        SceneManager.LoadScene("Dungeon", LoadSceneMode.Single);
    }
}
