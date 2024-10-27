using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Make sure to add this for UI elements

public enum GameState { FreeRoam, Battle }
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera worldCamera;
    [SerializeField] Text levelText;  // Reference to the level text UI element

    private int level = 1; // Initial level

    private void Start()
    {
        playerController.OnEncountered += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
        UpdateLevelText();  // Initialize the level text at the start
    }

    void StartBattle()
    {
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        worldCamera.gameObject.SetActive(false);

        battleSystem.StartBattle();
    }

    void EndBattle(bool won)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        worldCamera.gameObject.SetActive(true);

        if (won)
        {
            level++;  // Increase level if the battle is won
            UpdateLevelText();
        }
    }

    void UpdateLevelText()
    {
        levelText.text = "Level: " + level;
    }

    GameState state;

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }
}
