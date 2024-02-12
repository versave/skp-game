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
        List<CharacterSO> charactersList = ResourceSystem.Instance.charactersList;

        foreach (CharacterSO character in charactersList) {
            CreateCharacterButton(character);
        }
    }

    private void CreateCharacterButton(CharacterSO characterSo) {
        GameObject characterObj = Instantiate(characterButtonPrefab, characterGrid.transform);
        Button buttonComponent = characterObj.GetComponent<Button>();
        Image imageComponent = characterObj.GetComponentsInChildren<Image>()[1];
        TextMeshProUGUI textComponent = characterObj.GetComponentInChildren<TextMeshProUGUI>();

        buttonComponent.name = characterSo.displayName;
        imageComponent.sprite = characterSo.menuSprite;
        textComponent.text = characterSo.displayName;

        buttonComponent.onClick.AddListener(() => OnCharacterButtonClick(characterSo));
    }

    private void OnCharacterButtonClick(CharacterSO characterSo) {
        GameManager.Instance.selectedCharacterId = characterSo.characterId;
        GameManager.Instance.LoadScene(Scenes.Game);
    }
}