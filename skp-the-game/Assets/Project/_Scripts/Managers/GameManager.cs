using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NonMonoSingleton<GameManager> {
    public UniqueCharacterId selectedCharacterId { get; set; } = UniqueCharacterId.Valio;

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadScene(Scenes scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}

public enum Scenes {
    MainMenu,
    Game
}