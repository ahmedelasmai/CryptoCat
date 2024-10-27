using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;
    public event Action<bool> OnBattleOver;
    BattleState state;
    int currentAction;
    int currentMove;

    public void StartBattle()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Cat);
        enemyHud.SetData(enemyUnit.Cat);

        dialogBox.SetMoveNames(playerUnit.Cat.Moves);
        Debug.Log("Number of moves: " + playerUnit.Cat.Moves.Count);
        foreach (var move in playerUnit.Cat.Moves)
        {
            Debug.Log("Move: " + move.Base.Name);
        }

        yield return dialogBox.TypeDialog($"A wild {enemyUnit.Cat.Base.Name} appeared.");
        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove() 
    { 
        state = BattleState.Busy;
        var move = playerUnit.Cat.Moves[currentMove]; 
        yield return dialogBox.TypeDialog($"{playerUnit.Cat.Base.Name} used {move.Base.Name}");
        playerUnit.PlayAttackAnimation();
        yield return new WaitForSeconds (1f);
        enemyUnit.PlayHitAnimation();
        enemyUnit.Cat.TakeDamage(move, playerUnit.Cat);
        var damageDetails = enemyUnit.Cat.TakeDamage (move, playerUnit.Cat);
        yield return enemyHud.UpdateHP();
        yield return ShowDamageDetails(damageDetails);
        if (damageDetails.Fainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.Cat.Base.Name} Fainted");
            enemyUnit.PlayFaintAnimation();

            yield return new WaitForSeconds (2f); 
            OnBattleOver(true);
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }
    IEnumerator EnemyMove()
        {
            state = BattleState.EnemyMove;
            var move  = enemyUnit.Cat.GetRandomMove();
            yield return dialogBox.TypeDialog($"{enemyUnit.Cat.Base.Name} used {move.Base.Name}");
            enemyUnit.PlayAttackAnimation();
            yield return new WaitForSeconds (1f);
            playerUnit. PlayHitAnimation();
            var damageDetails = playerUnit.Cat.TakeDamage (move, playerUnit.Cat);
            playerUnit.PlayAttackAnimation();
            yield return ShowDamageDetails(damageDetails);
            yield return playerHud.UpdateHP();
            playerUnit.PlayAttackAnimation();
            if (damageDetails.Fainted)
            {
                yield return dialogBox.TypeDialog($"{playerUnit.Cat.Base.Name} Fainted");
                playerUnit.PlayFaintAnimation();

                yield return new WaitForSeconds (2f); 
                OnBattleOver(false);
            }
            else
            {
                PlayerAction();
            }
        }
        IEnumerator ShowDamageDetails(DamageDetails damageDetails)
        {
            if (damageDetails.Critical > 1f)
                yield return dialogBox. TypeDialog("A critical hit!");
            else if (damageDetails.Type > 1f)
                yield return dialogBox.TypeDialog("It's super effective!");
            else if (damageDetails.Type < 1f)
                yield return dialogBox.TypeDialog("It's not very affectivel");
        }
    public void HandleUpdate()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }
    void HandleActionSelection()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }

        dialogBox.UpdateActionSelection(currentAction);

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                // fight
                PlayerMove();
            }
            else if (currentAction == 1)
            {
                // Run
            }
        }
    }
    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Cat.Moves.Count - 1)
                ++currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
                --currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Cat.Moves.Count - 2)
                currentMove += 2;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1)
                currentMove -= 2;
        }

        // Clamp currentMove to ensure it's within valid range
        //currentMove = Mathf.Clamp(currentMove, 0, playerUnit.Cat.Moves.Count - 1);

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Cat.Moves[currentMove]);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox. EnableMoveSelector(false); 
            dialogBox. EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }

}
