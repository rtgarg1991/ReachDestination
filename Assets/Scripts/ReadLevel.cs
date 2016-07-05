using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

public class ReadLevel : MonoBehaviour {

	Game game = null;
	public Transform block;
	public Transform block_02;
	// Use this for initialization


	void Start () {

		XmlTextReader reader = new XmlTextReader ("/Users/Shared/Unity/ReachDestination/Assets/game.xml");
//		XmlTextReader reader = new XmlTextReader ("C:\\Users\\Rohit\\abc\\Assets\\game.xml");
		int x = 0, z = -1;
		Game.Board board = null;
		Game.Row row = null;
		while (reader.Read()) {
			switch (reader.NodeType) {
			case XmlNodeType.Element:
				if (reader.Name == "Game") {
					game = CreateGameObject ();
				} else if (reader.Name == "Board") {
					board = CreateBoardObject (reader);
					game.board = board;
				} else if (reader.Name == "Row") {
					Game.Row row1 = CreateRowObject (reader);
					if (board != null) {
						board.rows.Add (row1);
					}
					row = row1;
					x = 0;
					z++;
				} else if (reader.Name == "Block") {
					Game.Block block = CreateBlockObject (reader);
					if (row != null) {
						row.blocks.Add (block);
					}
					block.x = x;
					block.z = z;
					x++;
				}
				break;
			}
		}

		if(game != null) {
			for (int i = 0; i < game.board.height; i++) {
				Game.Row r = (Game.Row)game.board.rows[i];
				for (int j = 0; j < game.board.width; j++) {
					Game.Block b = (Game.Block)r.blocks [j];

					if (b.type == 1) {
						Instantiate (block, new Vector3 (b.x, 0, b.z), transform.rotation);
					}else if (b.type == 2) {
						Instantiate (block_02, new Vector3 (b.x, 0, b.z), transform.rotation);
					}
				}
			}
		}
	}

	Game CreateGameObject() {
		return new Game ();
	}
	Game.Board CreateBoardObject(XmlTextReader reader) {
		Game.Board board = new Game.Board ();
		if (reader.AttributeCount > 0) {
			for (int i = 0; i < reader.AttributeCount; i++) {
				reader.MoveToAttribute (i);
				if (reader.Name == "width") {
					board.width = int.Parse (reader.GetAttribute (i));
				} else if (reader.Name == "height") {
					board.height = int.Parse (reader.GetAttribute (i));
				}
			}
		}
		board.rows = new ArrayList ();
		return board;
	}
	Game.Row CreateRowObject(XmlTextReader reader) {
		Game.Row row = new Game.Row ();
		row.blocks = new ArrayList ();
		return row;
	}
	Game.Block CreateBlockObject(XmlTextReader reader) {
		Game.Block block = new Game.Block ();
		if (reader.AttributeCount > 0) {
			for (int i = 0; i < reader.AttributeCount; i++) {
				reader.MoveToAttribute (i);
				if (reader.Name == "type") {
					block.type = int.Parse (reader.GetAttribute (i));
				} else if (reader.Name == "isDestination") {
					block.isDestination = bool.Parse (reader.GetAttribute (i));
				} else if (reader.Name == "isSource") {
					block.isSource = bool.Parse (reader.GetAttribute (i));
				}
			}
		}
		return block;
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
