using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections;

public class Game {
	public Board board;

	public class Board {
		public int width;
		public int height;

		public ArrayList rows;
	}

	public class Row {

		public ArrayList blocks;
	}

	public class Block {
		public int type;
		public bool isDestination;
		public bool isSource;
		public int x, z;
	}
}