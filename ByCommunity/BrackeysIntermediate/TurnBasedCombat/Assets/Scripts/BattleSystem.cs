using System;
using System.Collections;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleState state;

    public Text dialogueText;

    public BattleHUD playerBattleHUD;
    public BattleHUD enemyBattleHUD;

    Unit playerUnit;
    Unit enemyUnit;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        playerUnit = Instantiate(playerPrefab, playerBattleStation).GetComponent<Unit>();
        enemyUnit = Instantiate(enemyPrefab, enemyBattleStation).GetComponent<Unit>();

        dialogueText.text = enemyUnit.unitName + " gets to battlefield!";

        playerBattleHUD.SetHUD(playerUnit);
        enemyBattleHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }

    private IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerBattleHUD.SetHP(playerUnit.currentHP);

        dialogueText.text = "You feel better now";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    private void PlayerTurn()
    {
        dialogueText.text = "Choose an Action: ";
    }

    private IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamge(enemyUnit.damage);

        playerBattleHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    private IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamge(playerUnit.damage);

        enemyBattleHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = "Attacked to the enemy.";
        
        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        yield return new WaitForSeconds(2f);
    }


    private void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You have won the battle.";
        }
        else if(state == BattleState.LOST)
        {
            dialogueText.text = "You have been defeated";
        }
    }
}
