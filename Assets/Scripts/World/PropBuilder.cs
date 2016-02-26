using UnityEngine;
using System.Collections;

public class PropBuilder : MonoBehaviour {
	
	public GameObject propSprite;
	private ArrayList GroundBlocksArray;
	private ArrayList PropBlocksArray = new ArrayList();
	public int Num;
	public int Props;
	public int wait = 20;
	public void BuildProp(GameObject Block)
	{
		GenerateProp( Block );
	}
	
	public void BuildPropArray(ArrayList ArrayList)
	{
		GroundBlocksArray = ArrayList;
		foreach (GameObject Block in GroundBlocksArray)
		{
			GenerateProp( Block );
		}
	}
	
	public void GenerateProp(GameObject Block)
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
		var SpawnValid = false;
		foreach(GameObject Block in GroundBlocksArray )
		{
			if( Block.transform.position == OffsetLocation )
			{
				SpawnValid = true;	
			}
		}
		foreach(GameObject Block in PropBlocksArray )
		{
			if( Block.transform.position == OffsetLocation )
			{
				SpawnValid = true;


			}
		}

		if (SpawnValid == true) {
			/*Num = 0;	
			Num = Random.Range (1, 1);

			Debug.Log(Num);
			if(wait >= 0){
				if (Num == 1)
				{
					if (Props >= 0) {
						SpawnPropBlock (OffsetLocation);
						Props --;
					}
				}
				else wait --;

				}*/
		}
	}
	
	public void SpawnPropBlock(Vector3 OffsetLocation)
	{
		GameObject propblock = GameObject.Instantiate( propSprite, OffsetLocation, Quaternion.identity) as GameObject;
		propblock.transform.parent = transform.FindChild("Prop");
		PropBlocksArray.Add(propblock);
	}
	
	public void SelectRandomPropBlocks()
	{
		for (int i = 0; i < 3; i++) 
		{
			int RandomPropBlock = Random.Range( 0, PropBlocksArray.Count -1 );
			GameObject PossibleEdgeBlock = PropBlocksArray[RandomPropBlock] as GameObject;
			PossibleEdgeBlock.GetComponent<Renderer>().material.color = Color.red;
		}
	}
}
