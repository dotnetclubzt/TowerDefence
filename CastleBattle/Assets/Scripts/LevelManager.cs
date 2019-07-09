using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
	[SerializeField]
	private GameObject [] tilePrefabs;
	
	public float TileSize
	{
		get {return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;}
	}
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void CreateLevel()
	{
        string[] mapData = new string[]
        {
            "0000000000", "1111111111","0000000000","1111111111","0000000000","1111111111",
        };

 
        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;
		Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

		 for(int axisY = 0; axisY < mapY; axisY++){

             char[] newTiles = mapData[axisY].ToCharArray();

			 for(int axisX = 0; axisX < mapX; axisX++){
				PlaceTile(newTiles[axisX].ToString(),axisX, axisY,worldStart);
			 }		 
		 }
	}
	
	private void PlaceTile(string tyleType, int axisX, int axisY, Vector3 worldStart){

        int tileIndex = int.Parse(tyleType);

		GameObject newTile = Instantiate(tilePrefabs[0]);
		newTile.transform.position = new Vector3(worldStart.x + (TileSize * axisX), worldStart.y -(TileSize * axisY),0);
	}
}
