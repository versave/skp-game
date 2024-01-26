using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject selectCharacterMenu;
    [SerializeField] private GameObject characterGrid;
    [SerializeField] private GameObject characterButtonPrefab;

    private void Start() {
        RenderCharacterButtons();
    }

    public void ShowSelectCharacterMenu() {
        startMenu.SetActive(false);
        selectCharacterMenu.SetActive(true);
    }

    public void ShowStartMenu() {
        startMenu.SetActive(true);
        selectCharacterMenu.SetActive(false);
    }

    public void QuitGame() {
        GameManager.Instance.QuitGame();
    }

    private void RenderCharacterButtons() {
        List<Character> charactersList = ResourceSystem.Instance.characters;

        foreach (Character character in charactersList) {
            CreateCharacterButton(character);
        }
    }

    private void CreateCharacterButton(Character character) {
        GameObject characterObj = Instantiate(characterButtonPrefab, characterGrid.transform);
        Button buttonComponent = characterObj.GetComponent<Button>();
        Image imageComponent = characterObj.GetComponentsInChildren<Image>()[1];
        TextMeshProUGUI textComponent = characterObj.GetComponentInChildren<TextMeshProUGUI>();

        buttonComponent.name = character.displayName;
        imageComponent.sprite = character.menuSprite;
        textComponent.text = character.displayName;

        buttonComponent.onClick.AddListener(() => OnCharacterButtonClick(character));
    }

    private void OnCharacterButtonClick(Character character) {
        GameManager.Instance.selectedCharacterId = character.characterId;
        GameManager.Instance.LoadScene(Scenes.Game);
    }
}