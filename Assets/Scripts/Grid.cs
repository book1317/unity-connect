using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int x;
    public int y;
    public string color = "White";
    private SpriteRenderer sprite;
    public GameObject gridObject;

    public Grid(int x, int y, SpriteRenderer sprite, GameObject gridObject)
    {
        this.x = x;
        this.y = y;
        this.sprite = sprite;
        this.gridObject = gridObject;
    }

    public void SetColor(string color)
    {
        switch (color)
        {
            case "Red":
                this.color = "Red";
                sprite.color = Color.red;
                break;
            case "Blue":
                this.color = "Blue";
                sprite.color = Color.blue;
                break;
        }
    }
}
