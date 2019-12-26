using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerController : MonoBehaviour
{
    public int x;
    private LevelController theLevel;

    void Start()
    {
        theLevel = FindObjectOfType<LevelController>();
    }


    void OnMouseDown()
    {
        if (theLevel.currentState == LevelController.GameState.Playing)
        {
            int y = 0;
            while (y < theLevel.gridSizeY && !theLevel.allGrid[x, y].color.Equals("White"))
                y++;

            if (y < theLevel.gridSizeY)
            {
                theLevel.allGrid[x, y].SetColor(theLevel.currentTurn);
                if (!theLevel.CheckWin(theLevel.allGrid[x, y]))
                    theLevel.SwitchTurn();
            }
        }
    }
}
