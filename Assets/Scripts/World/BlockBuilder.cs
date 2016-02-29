using UnityEngine;
using System.Collections;


public class BlockBuilder : MonoBehaviour 
{

	public string levelName;
	public GameObject groundSprite;
	public int numberOfGroundTilesToSpawn = 5;
	public int OffsetDistance = 1;
	public bool generateBorder = true;
	public bool generateProp = true;

	private int MaxRandomOptionRange = 12;
	private ArrayList GroundBlocksArray = new ArrayList();
	private Vector3 OffsetLocation = new Vector3(0f, 0f, 0f);



	void Start()
	{
		numberOfGroundTilesToSpawn = numberOfGroundTilesToSpawn + NextLevel.levelDificulty;
		GroundBlocksArray.Add(gameObject);
		Vector3 SpawnPoint = transform.position;
		StartCoroutine(BuildBlocks(numberOfGroundTilesToSpawn, SpawnPoint));
		transform.name = levelName;
	}
	private IEnumerator BuildBlocks (int Quantity, Vector3 SpawnPoint) 
	{
		while( GroundBlocksArray.Count < Quantity )
		{
			yield return new WaitForSeconds(.01f);
			int randomnumber = Random.Range(1,MaxRandomOptionRange);
			int randomspawncount = Random.Range(1,4);
			switch( randomnumber )
			{
			case 1:
				OffsetLocation = new Vector3(SpawnPoint.x + OffsetDistance, SpawnPoint.y, 0f);
				SpawnCollisionCheck( OffsetLocation );
				SpawnPoint = OffsetLocation;
				break;
			case 2:
				OffsetLocation = new Vector3(SpawnPoint.x, SpawnPoint.y + OffsetDistance, 0f);
				SpawnCollisionCheck( OffsetLocation );
				SpawnPoint = OffsetLocation;
				break;
			case 3:
				OffsetLocation = new Vector3(SpawnPoint.x, SpawnPoint.y - OffsetDistance, 0f);
				SpawnCollisionCheck( OffsetLocation );
				SpawnPoint = OffsetLocation;
				break;
			case 4:
				OffsetLocation = new Vector3(SpawnPoint.x - OffsetDistance, SpawnPoint.y, 0f);
				SpawnCollisionCheck( OffsetLocation );
				SpawnPoint = OffsetLocation;
				break;
			case 5:
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x ,SpawnPoint.y + OffsetDistance, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				break;
			case 6:
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x ,SpawnPoint.y - OffsetDistance, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				break;
			case 7:
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x + OffsetDistance , SpawnPoint.y, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				break;
			case 8:
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x - OffsetDistance ,SpawnPoint.y, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				break;
			case 9:
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x - OffsetDistance ,SpawnPoint.y, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				OffsetLocation = new Vector3(SpawnPoint.x,SpawnPoint.y - OffsetDistance, 0f);
				SpawnCollisionCheck( OffsetLocation );
				SpawnPoint = OffsetLocation;

				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x + OffsetDistance ,SpawnPoint.y, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				break;
			case 10:
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x + OffsetDistance ,SpawnPoint.y, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				OffsetLocation = new Vector3(SpawnPoint.x,SpawnPoint.y + OffsetDistance, 0f);
				SpawnCollisionCheck( OffsetLocation );
				SpawnPoint = OffsetLocation;

				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x - OffsetDistance ,SpawnPoint.y, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				break;
			case 11:
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x ,SpawnPoint.y + OffsetDistance, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				OffsetLocation = new Vector3(SpawnPoint.x -OffsetDistance, SpawnPoint.y , 0f);
				SpawnCollisionCheck( OffsetLocation );
				SpawnPoint = OffsetLocation;
				for (int i = 0; i < randomspawncount; i++) 
				{
					OffsetLocation = new Vector3(SpawnPoint.x, SpawnPoint.y - OffsetDistance, 0f);
					SpawnCollisionCheck( OffsetLocation );
					SpawnPoint = OffsetLocation;
				}
				break;
			}
		}

		if( generateBorder )
			GetComponent<BorderBuilder>().BuildBorderArray(GroundBlocksArray);
		if( generateProp )
			GetComponent<PropBuilder>().BuildPropArray(GroundBlocksArray);

	}

	public bool SpawnCollisionCheck(Vector3 OffsetLocation)
	{
		var SpawnValid = true;
		foreach(GameObject b in GroundBlocksArray )
		{
			if( b.transform.position == OffsetLocation )
			{
				SpawnValid = false;
				return false;
			}
		}
		if( SpawnValid == true )
		{
			SpawnBlock( OffsetLocation );
			return true;
		}
		else
			return false;
	}

	public void SpawnBlock(Vector3 OffsetLocation)
	{
		GameObject groundTile = GameObject.Instantiate( groundSprite, OffsetLocation, Quaternion.identity) as GameObject;	
		GroundBlocksArray.Add( groundTile );
		groundTile.transform.position = OffsetLocation;
		groundTile.transform.parent = transform.FindChild("Ground");
	}
}
