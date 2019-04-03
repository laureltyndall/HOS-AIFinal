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
    public bool GameOver = false;
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
    public int SnakeMoveDirection;

    public SnakeState CurrentSnakeState = SnakeState.None;
	// Use this for initialization
	void Start () 
    {
        CurrentSnakeState = SnakeState.Move;
        GenerateAction = true;
        AttackButton.gameObject.SetActive(false);
        EvadeButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update()
    {

        if (GenerateAction)
        {
            if (CurrentSnakeState == SnakeState.Move)
            {
                GameActionTextBox.text = "";
                SnakeActionTimerInterval = Random.Range(1.25f, 2.5f);
                CurrentSnakeState = SnakeState.Attack;
                GenerateAction = false;
            }
            else if (CurrentSnakeState == SnakeState.Attack)
            {
                EvadeButton.gameObject.SetActive(true);
                PlayerDodge = true;
                GameActionTextBox.text = "Quick dodge the snake's bite!";
                SnakeActionTimerInterval = Random.Range(1.25f, 2f);
                PlayerActionTimerInterval = Random.Range(0.6f, 1.25f);
                CurrentSnakeState = SnakeState.Recover;
                GenerateAction = false;
            }
            else if (CurrentSnakeState == SnakeState.Recover)
            {
                PlayerAttack = true;
                AttackButton.gameObject.SetActive(true);
                GameActionTextBox.text = "I can probably strike the snake now before it coils back up.";
                SnakeActionTimerInterval = Random.Range(1.0f, 4f);
                PlayerActionTimerInterval = Random.Range(0.45f, 1.65f);
                SnakeMoveDirection = Random.Range(1, 2);
                CurrentSnakeState = SnakeState.Move;
                GenerateAction = false;
            }
        }

        if (SnakeActionTimer >= SnakeActionTimerInterval)
        {
            if (CurrentSnakeState == SnakeState.Move)
            {
                if (SnakeMoveDirection == 1)
                   SnakeObject.GetComponent<Rigidbody>().velocity = new Vector3(-5,0,0);
                else if (SnakeMoveDirection == 2)
                    SnakeObject.GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);
            }
            if (CurrentSnakeState == SnakeState.Attack)
            {
                if (!SnakeMissAttack)
                {
                    PlayerHP -= 1;
                }
                SnakeMissAttack = false;
                EvadeButton.gameObject.SetActive(false);
                PlayerActionTimer += Time.fixedDeltaTime;
            }
            if (CurrentSnakeState == SnakeState.Recover)
            {
                AttackButton.gameObject.SetActive(false);
                PlayerActionTimer += Time.fixedDeltaTime;
            }
            GameActionTextBox.text = "";
            SnakeActionTimer = 0;
            GenerateAction = true;

        }
             if (CurrentSnakeState == SnakeState.Move)
            {
                if (SnakeMoveDirection == 1)
                   SnakeObject.GetComponent<Rigidbody>().velocity = new Vector3(-5,0,0);
                else if (SnakeMoveDirection == 2)
                    SnakeObject.GetComponent<Rigidbody>().velocity = new Vector3(5,0,0);
            }
        MasterTimer += Time.fixedDeltaTime;
        SnakeActionTimer += Time.fixedDeltaTime;


        if (MasterTimer >= MasterTimerResetInterval)
        {
            MasterTimer = 0;
            GameActionTextBox.text = "";
            CurrentSnakeState = SnakeState.Move;
        }

        if (PlayerActionTimer >= PlayerActionTimerInterval)
        {
            if (PlayerAttack)
            {
                PlayerAttack = false;
                AttackButton.gameObject.SetActive(false);
                GameActionTextBox.text = "";

            }
            else if (PlayerDodge)
            {
                PlayerDodge = false;
                AttackButton.gameObject.SetActive(false);                
                GameActionTextBox.text = "";
            }
            PlayerActionTimer = 0;
        }
        DetermineGameOver();
	}

    public void DetermineGameOver()
    {
        
        if (SnakeHP <= 0)
        {
            GameActionTextBox.text = "Winner";
            PlayerWinsGame = true;
        }

        if (PlayerHP <= 0)
        {
            GameActionTextBox.text = "Dead";
            SnakeWinsGame = true;
        }
    }

    public void PlayerAttackButton()
    {
        if (PlayerAttack)
        {
            DamageSnake();
            PlayerAttack = false;
            AttackButton.gameObject.SetActive(false);
            PlayerActionTimer = 0;

        }
    }

    public void PlayerDodgeButton()
    {
        if (PlayerDodge)
        {
            SnakeMissAttack = true;
            PlayerDodge = false;
            EvadeButton.gameObject.SetActive(false);
            PlayerActionTimer = 0;
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
