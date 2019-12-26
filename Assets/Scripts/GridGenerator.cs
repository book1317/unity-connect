using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private GameObject clickerPrefab;
    private const float startX = -5;
    private const float startY = -3f;
    private const float gridGapX = 1.65f;
    private const float gridGapY = 1.2f;

    private LevelController theLevel;

    void Start()
    {
        theLevel = FindObjectOfType<LevelController>();
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        theLevel.allGrid = new Grid[theLevel.gridSizeX, theLevel.gridSizeY];
        for (int x = 0; x < theLevel.gridSizeX; x++)
            for (int y = 0; y < theLevel.gridSizeY; y++)
            {
                GameObject newCoin = Instantiate(gridPrefab, new Vector3(startX + x * gridGapX, startY + y * gridGapY, transform.position.z), Quaternion.identity);
                // GameObject newClicker = Instantiate(clickerPrefab, new Vector3(startX + x * gridGapX, startY + y * gridGapY, transform.position.z), Quaternion.identity);
                //newClicker.GetComponent<ClickerController>().x = x;
                newCoin.GetComponentInChildren<ClickerController>().x = x;
                newCoin.transform.SetParent(this.transform);
                theLevel.allGrid[x, y] = new Grid(x, y, newCoin.GetComponent<SpriteRenderer>(), newCoin);
            }
    }

    public void DestroyAllGrid()
    {
        for (int x = 0; x < theLevel.gridSizeX; x++)
            for (int y = 0; y < theLevel.gridSizeY; y++)
            {
                Destroy(theLevel.allGrid[x, y].gridObject);
            }
    }

}
