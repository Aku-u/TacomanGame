using UnityEngine;
using System.Collections;

public class BorderBuilder : MonoBehaviour {
	
	public GameObject borderSprite;
	private ArrayList GroundBlocksArray;
	private ArrayList BorderBlocksArray = new ArrayList();

	public void BuildBorder(GameObject Block)
	{
		GenerateBorder( Block );
	}
	
	public void BuildBorderArray(ArrayList ArrayList)
	{
		GroundBlocksArray = ArrayList;
		foreach (GameObject Block in GroundBlocksArray)
		{
			GenerateBorder( Block );
		}
	}
	
	public void GenerateBorder(GameObject Block)
	{
		var OffsetDistance = 2;
		var OffsetLocation = new Vector3( 0f, 0f, 0f );

		OffsetLocation = new Vector3(Block.transform.position.x + OffsetDistance, Block.transform.position.y, 0f);
		SpawnCollisionCheck( OffsetLocation );

		OffsetLocation = new Vector3(Block.transform.position.x, Block.transform.position.y + OffsetDistance, 0f);
		SpawnCollisionCheck( OffsetLocation );
		
		OffsetLocation = new Vector3(Block.transform.position.x - OffsetDistance, Block.transform.position.y, 0f);
		SpawnCollisionCheck( OffsetLocation );
		
		OffsetLocation = new Vector3(Block.transform.position.x, Block.transform.position.y - OffsetDistance, 0f);
		SpawnCollisionCheck( OffsetLocation );
		
		OffsetLocation = new Vector3(Block.transform.position.x - OffsetDistance, Block.transform.position.y - OffsetDistance, 0f);
		SpawnCollisionCheck( OffsetLocation );
		
		OffsetLocation = new Vector3(Block.transform.position.x + OffsetDistance, Block.transform.position.y + OffsetDistance, 0f);
		SpawnCollisionCheck( OffsetLocation );
		
		OffsetLocation = new Vector3(Block.transform.position.x - OffsetDistance, Block.transform.position.y + OffsetDistance, 0f);
		SpawnCollisionCheck( OffsetLocation );
		
		OffsetLocation = new Vector3(Block.transform.position.x + OffsetDistance, Block.transform.position.y - OffsetDistance, 0f);
		SpawnCollisionCheck( OffsetLocation );
	}
	
	public void SpawnCollisionCheck(Vector3 OffsetLocation)
	{
		var SpawnValid = true;
		foreach(GameObject Block in GroundBlocksArray )
		{
			if( Block.transform.position == OffsetLocation )
			{
				SpawnValid = false;	
			}
		}
		foreach(GameObject Block in BorderBlocksArray )
		{
			if( Block.transform.position == OffsetLocation )
			{
				SpawnValid = false;	
			}
		}
		if( SpawnValid == true )
			SpawnBorderBlock( OffsetLocation );
	}
	
	public void SpawnBorderBlock(Vector3 OffsetLocation)
	{
		GameObject borderblock = GameObject.Instantiate( borderSprite, OffsetLocation, Quaternion.identity) as GameObject;
		borderblock.transform.parent = transform.FindChild("Border");
		BorderBlocksArray.Add(borderblock);
	}
	
	public void SelectRandomBorderBlocks()
	{
		for (int i = 0; i < 3; i++) 
		{
			int RandomBorderBlock = Random.Range( 0, BorderBlocksArray.Count -1 );
			GameObject PossibleEdgeBlock = BorderBlocksArray[RandomBorderBlock] as GameObject;
			PossibleEdgeBlock.GetComponent<Renderer>().material.color = Color.red;
		}
	}
}
