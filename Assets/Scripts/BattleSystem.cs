using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState
{
    start, 
    playerTurn,
    enemyTurn,
    won,
    lost
};

public class BattleSystem : MonoBehaviour
{
    public BattleState battleState;

    public GameObject battleCanvas;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public PlayerUnit playerUnit;
    public Unit enemyUnit;

    public TMP_Text dialogText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public event Action OnEnterBattle;
    public event Action OnLeaveBattle;

    // Start is called before the first frame update
    void Start()
    {
        battleState = BattleState.start;
        OnEnterBattle?.Invoke();
        battleCanvas.SetActive(true);
        StartCoroutine(SetUpBattle()); 
    }

    public void StartBattle()
    {
        battleState = BattleState.start;
        OnEnterBattle?.Invoke();
        battleCanvas.SetActive(true);
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = player.GetComponent<PlayerUnit>();

        GameObject enemy = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemy.GetComponent<Unit>();

        dialogText.text = "A wild " + enemyUnit.unitName + "comes closer";

        playerHUD.SetHUDPlayer(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        battleState = BattleState.playerTurn;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogText.text = "Hit!";

        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            battleState = BattleState.won;
            EndBattle();
        }
        else
        {
            battleState = BattleState.enemyTurn;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            battleState = BattleState.lost;
            EndBattle();
        }
        else
        {
            battleState = BattleState.playerTurn;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(battleState == BattleState.won)
        {
            dialogText.text = "You are victorious!";
            ExperianceManager experianceManager = GameObject.Find("StatManager").GetComponent<ExperianceManager>();
            experianceManager.AddExp(enemyUnit.expOnDeath);
        } else if (battleState == BattleState.lost)
        {
            dialogText.text = "You were defeated...";
        }
        OnLeaveBattle?.Invoke();
        battleCanvas.SetActive(false);
        this.gameObject.SetActive(false);
    }

    void PlayerTurn()
    {
        dialogText.text = "Choose an action:";
    }

    public void OnAttackButton()
    {
        if (battleState != BattleState.playerTurn)
            return;

        StartCoroutine(PlayerAttack());
    }


}
