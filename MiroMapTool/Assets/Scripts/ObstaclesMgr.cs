using UnityEngine;
using System.Collections;
using System.IO;

public class ObstaclesMgr : MonoBehaviour {
    static private ObstaclesMgr instance;
    public int[ , , ] maze = {
		{
			{1,1,1,1},
			{1,1,1,1},
			{1,1,1,1},
            {1,1,1,1}
		},

		{
			{1,1,1,1},
			{1,1,1,1},
			{1,1,1,1},
            {1,1,1,1}
		},

		{
			{1,1,1,1},
			{1,1,1,1},
			{1,1,1,1},
            {1,1,1,1}
		},

        {
			{1,1,1,1},
			{1,1,1,1},
			{1,1,1,1},
            {1,1,1,1}
		}
	};

    public GameObject miro;
    public GameObject obstacle;
    public GameObject preview;
    public GameObject start;

    private GameObject[] obstacles;
    private GameObject[] previews;
    private StartPoint sp1;
    private StartPoint sp2;


    static public ObstaclesMgr Instance {
        get {
            if ( instance == null ) {
                instance = FindObjectOfType( typeof( ObstaclesMgr ) ) as ObstaclesMgr;

                if ( instance == null ) {

                    instance = new GameObject( "ObstacleMgr", typeof( ObstaclesMgr ) ).GetComponent<ObstaclesMgr>();
                }
            }

            return instance;
        }
    }
     

    void Awake ( ) {
    }


    // Use this for initialization
    void Start ( ) {
    }

    // Update is called once per frame
    void Update ( ) {
        //if ( Input.GetKeyUp(KeyCode.Space) ) {
        //    int number = 0;
        //    string fileName = string.Format( "output{0}.txt", number );
        //    Debug.Log( "??" );

        //    while ( File.Exists( fileName ) ) {
        //        number++;
        //        fileName = string.Format( "output{0}.txt", number );
        //    }



        //    Debug.Log( fileName );
        //}
    }

    public void MakeObstacles ( ) {
        int length = maze.Length;
        obstacles = new GameObject[ length ];
        previews = new GameObject[ length ];

        for ( int i = 0; i < 4; i++ ) {
            for ( int j = 0; j < 4; j++ ) {
                for ( int k = 0; k < 4; k++ ) {

                    int nine = i * 4 * 4;
                    int three = j * 4;
                    int index = nine + three + k;
                    Debug.Log( index );
                    int reverseIndex = ( maze.Length - index );

                    {
                        obstacles[ index ] = Instantiate( obstacle ) as GameObject;
                        var sObj = obstacles[ index ];
                        var sTransform = sObj.transform;
                        var sPosition = sTransform.position;

                        sPosition.x = 1.8f - 1.2f * i;
                        sPosition.y = 1.2f * j - 1.8F;
                        sPosition.z = 1.2f * k - 1.8f;

                        sTransform.position = sPosition;
                    }


                    {
                        previews[ index ] = Instantiate( preview ) as GameObject;
                        var sObj = previews[ index ];
                        var childText = sObj.GetComponentInChildren<TextMesh>() as TextMesh;
                        childText.text = (maze.Length - index).ToString();

                        var sTransform = sObj.transform;
                        var sPosition = sTransform.position;

                        sPosition.x = 1.2f;
                        sPosition.y = 1.2f * j - 1.8f;
                        sPosition.z = 70f + 1.2f * k + 20f * ( i + 1 ) - 1.2f;

                        sTransform.position = sPosition;

                        var destroyer = sObj.GetComponent<Destroy>() as Destroy;
                        destroyer.companion = obstacles[ index ];
                    }

                    if ( reverseIndex == 4 ) {
                        sp1 = ( Instantiate( start ) as GameObject ).GetComponent<StartPoint>() as StartPoint;

                        sp1.startPoint = obstacles[ index ];

                        sp2 = ( Instantiate( start ) as GameObject ).GetComponent<StartPoint>() as StartPoint;

                        sp2.startPoint = previews[ index ];
                    }
                }
            }
        }
    }
}
