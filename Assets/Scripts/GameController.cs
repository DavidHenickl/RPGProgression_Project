using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle, GameOver }

public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] PlayerManager playerManager;

    GameState state;

    private void Start()
    {
        DialogManager.instance.OnShowDialog += () =>
        {
            state = GameState.Dialog;
        };
        DialogManager.instance.OnHideDialog += () =>
        {
            if (state == GameState.Dialog)
            {
                state = GameState.FreeRoam;
            }
        };
        battleSystem.OnEnterBattle += () => 
        {
            state = GameState.Battle;
        };
        battleSystem.OnLeaveBattle += () => 
        {
            state = GameState.FreeRoam;
        };
        playerManager.OnGameOver += () =>
        {
            state = GameState.GameOver;
        };

    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        } else if (state == GameState.Dialog)
        {
            DialogManager.instance.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {

        }
    }
}
