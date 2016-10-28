using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuButtons : MonoBehaviour {
    public Text invisibleHeroes;
    public Text loading;
    public Button start;
    public Button story;
    public Button exit;
    public Button backButton;
    public Button instructionsButton;
    public Button advancedSettingsButton;
    public Button knownIssues;
    public ScrollRect storyText;
    public ScrollRect instructionsText;
    public ScrollRect advancedSettingsText;
    public ScrollRect knownIssuesText;

    

	// Use this for initialization
	void Start () {
        storyText.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        advancedSettingsText.gameObject.SetActive(false);
        knownIssuesText.gameObject.SetActive(false);
	}

    public void StartGame()
    {
        invisibleHeroes.gameObject.SetActive(false);
        loading.gameObject.SetActive(true);
        KnownIssuesShow();
        SceneManager.LoadScene("Game");
    }

    public void Story()
    {
        storyText.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        storyText.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        knownIssuesText.gameObject.SetActive(false);
        advancedSettingsText.gameObject.SetActive(false);
        start.gameObject.SetActive(true);
        story.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }

    public void InstructionsShow()
    {
        storyText.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(true);
        knownIssuesText.gameObject.SetActive(false);
        advancedSettingsText.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    public void KnownIssuesShow()
    {
        storyText.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        knownIssuesText.gameObject.SetActive(true);
        advancedSettingsText.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    public void AdvancedSettingsShow()
    {
        storyText.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        knownIssuesText.gameObject.SetActive(false);
        advancedSettingsText.gameObject.SetActive(true);
        start.gameObject.SetActive(false);
        story.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
