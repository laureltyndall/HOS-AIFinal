using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMiniGameController : MonoBehaviour 
{
    public int SnakeHP = 3;
    public int PlayerHP = 3;
    public float PlayerActionTimer;
    public float SnakeActionTimer;
    public bool PlayerWinsGame = false;
    public bool SnakeWinsGame = false;
    public float PlayerActionTimerInterval = 0;
    public float SnakeActionTimerInterval = 0;
    public float MasterTimer = 0.0f;
    public float MasterTimerResetInterval = 8.5f;
    public GameObject SnakeObject;
    public Button AttackButton;
    public Button EvadeButton;
    public Text GameActionTextBox;
    public bool PlayerAttack = false;
    public bool PlayerDodge = false;
    public bool GenerateAction = true;
    public bool SnakeMissAttack = false;

    public SnakeState CurrentSnakeState = SnakeState.None;
	// Use this for initialization
	void Start () 
    {
        CurrentSnakeState = SnakeState.Move;
	}
	
	// Update is called once per frame
	void Update()
    {
        if (GenerateAction)
        {
            if (CurrentSnakeState == SnakeState.Move)
            {
                SnakeActionTimerInterval = Random.Range(1.25f, 2.5f);
                CurrentSnakeState = SnakeState.Attack;
                GenerateAction = false;
            }
            else if (CurrentSnakeState == SnakeState.Attack)
            {
                SnakeActionTimerInterval = Random.Range(1.25f, 2f);
                PlayerActionTimerInterval = Random.Range(0.6f, 1.25f);
                CurrentSnakeState = SnakeState.Recover;
                GenerateAction = false;
            }
            else if (CurrentSnakeState == SnakeState.Recover)
            {
                SnakeActionTimerInterval = Random.Range(1.0f, 4f);
                PlayerActionTimerInterval = Random.Range(0.45f, 1.65f);
                CurrentSnakeState = SnakeState.Move;
                GenerateAction = false;
            }
        }

        if (CurrentSnakeState == SnakeState.Move)
        {
        }
        if (CurrentSnakeState == SnakeState.Attack)
        {
        }
        if (CurrentSnakeState == SnakeState.Hurt)
        {
        }
        if (CurrentSnakeState == SnakeState.Recover)
        {
        }
        
        MasterTimer += Time.fixedDeltaTime;
        SnakeActionTimer += Time.fixedDeltaTime;
        PlayerActionTimer += Time.fixedDeltaTime;

        if (MasterTimer >= MasterTimerResetInterval)
        {
            MasterTimer = 0;
            CurrentSnakeState = SnakeState.Move;
        }

        if (SnakeActionTimer >= SnakeActionTimerInterval)
        {
            GenerateAction = true;
        }

        if (PlayerActionTimer >= PlayerActionTimerInterval)
        {
            if (PlayerAttack)
            {
                PlayerAttack = false;
            }
            else if (PlayerDodge)
            {
                PlayerDodge = false;
            }
        }

		DetermineGameOver();
	}

    public void DetermineGameOver()
    {
        
        if (SnakeHP == 0)
        {
            PlayerWinsGame = true;
        }

        if (PlayerHP == 0)
        {
            SnakeWinsGame = true;
        }
    }

    public void PlayerAttackButton()
    {
        if (PlayerAttack)
        {
            SnakeHP -= 1;
            PlayerAttack = false;
        }
    }

    public void PlayerDodgeButton()
    {
        if (PlayerDodge)
        {
            SnakeMissAttack = true;
        }
    }

    public void DamageSnake()
    {
        SnakeHP -= 1;
    }

    public void DamagePlayer()
    {
        PlayerHP -= 1;
    }
}
