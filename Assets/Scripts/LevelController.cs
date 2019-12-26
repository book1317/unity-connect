using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public enum GameState
    {
        MainMenu, Playing
    }

    public GameState currentState = GameState.Playing;
    public string currentTurn = "Red";
    public int gridSizeX;
    public int gridSizeY;
    public Grid[,] allGrid;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private Text gameStateText;
    private GridGenerator theGenerator;

    void Start()
    {
        theGenerator = FindObjectOfType<GridGenerator>();
        SetTextCurrentTurn();
    }

    public void SwitchTurn()
    {
        switch (currentTurn)
        {
            case "Red":
                currentTurn = "Blue";
                gameStateText.color = Color.blue;
                break;
            case "Blue":
                currentTurn = "Red";
                gameStateText.color = Color.red;
                break;
        }
        gameStateText.text = currentTurn;
    }

    void SetTextCurrentTurn()
    {
        switch (currentTurn)
        {
            case "Red":
                gameStateText.color = Color.red;
                break;
            case "Blue":
                gameStateText.color = Color.blue;
                break;
        }
        gameStateText.text = currentTurn;
    }

    public bool CheckWin(Grid grid)
    {
        Grid currentGrid = grid;
        string currentColor = currentGrid.color;
        int counter = 0;

        //Left
        counter = 0;
        while (currentGrid.x - 1 >= 0 && allGrid[currentGrid.x - 1, currentGrid.y].color.Equals(currentColor))
        {
            currentGrid = allGrid[currentGrid.x - 1, currentGrid.y];
            counter++;
            if (counter >= 3)
            {
                Win();
                return true;
            }
        }

        //Right
        counter = 0;
        currentGrid = grid;
        while (currentGrid.x + 1 < gridSizeX && allGrid[currentGrid.x + 1, currentGrid.y].color.Equals(currentColor))
        {
            currentGrid = allGrid[currentGrid.x + 1, currentGrid.y];
            counter++;
            if (counter >= 3)
            {
                Win();
                return true;
            }
        }

        //Down
        counter = 0;
        currentGrid = grid;
        while (currentGrid.y - 1 >= 0 && allGrid[currentGrid.x, currentGrid.y - 1].color.Equals(currentColor))
        {
            currentGrid = allGrid[currentGrid.x, currentGrid.y - 1];
            counter++;
            if (counter >= 3)
            {
                Win();
                return true;
            }
        }

        //Left Up
        counter = 0;
        currentGrid = grid;
        while (currentGrid.x - 1 >= 0 && currentGrid.y + 1 < gridSizeY && allGrid[currentGrid.x - 1, currentGrid.y + 1].color.Equals(currentColor))
        {
            currentGrid = allGrid[currentGrid.x - 1, currentGrid.y + 1];
            counter++;
            if (counter >= 3)
            {
                Win();
                return true;
            }
        }

        //Right Up
        counter = 0;
        currentGrid = grid;
        while (currentGrid.x + 1 < gridSizeX && currentGrid.y + 1 < gridSizeY && allGrid[currentGrid.x + 1, currentGrid.y + 1].color.Equals(currentColor))
        {
            currentGrid = allGrid[currentGrid.x + 1, currentGrid.y + 1];
            counter++;
            if (counter >= 3)
            {
                Win();
                return true;
            }
        }

        //Left Down
        counter = 0;
        currentGrid = grid;
        while (currentGrid.x - 1 >= 0 && currentGrid.y - 1 >= 0 && allGrid[currentGrid.x - 1, currentGrid.y - 1].color.Equals(currentColor))
        {
            currentGrid = allGrid[currentGrid.x - 1, currentGrid.y - 1];
            counter++;
            if (counter >= 3)
            {
                Win();
                return true;
            }
        }

        //Right Down
        counter = 0;
        currentGrid = grid;
        while (currentGrid.x + 1 < gridSizeX && currentGrid.y - 1 >= 0 && allGrid[currentGrid.x + 1, currentGrid.y - 1].color.Equals(currentColor))
        {
            currentGrid = allGrid[currentGrid.x + 1, currentGrid.y - 1];
            counter++;
            if (counter >= 3)
            {
                Win();
                return true;
            }
        }

        return false;
    }

    void Win()
    {
        currentState = GameState.MainMenu;
        restartButton.SetActive(true);
        gameStateText.text = currentTurn + " Win";
    }

    public void RestartGame()
    {
        theGenerator.DestroyAllGrid();
        theGenerator.GenerateGrid();
        restartButton.SetActive(false);
        SwitchTurn();
        SetTextCurrentTurn();
        currentState = GameState.Playing;
    }
}
