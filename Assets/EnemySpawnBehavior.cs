using UnityEngine;
using System.Collections;

public class EnemySpawnBehavior : MonoBehaviour {

	public GameObject ShapeManager;
	private ShapeBehavior shapebehavior; 
	private int alto = 2;
	private int ancho = 4;
	private int x0; //Posicion de la camara
	private int y0;
	private float camera_height; //alto y ancho de la camara
	private int camera_width;
	private float block_size;
	private float snapval = 1f; //Para que aproxime a una posicion en intervalos de 1.5 (1.46->1.5)
	private float invsnap;
	FigureTemplate figure;
	bool spawnReady = false;
	// Use this for initialization
	void prepareSpawn()
	{
		spawnReady = true;
	}

	void Start () {
		ShapeBehavior original = (ShapeBehavior)ShapeManager.GetComponent(typeof(ShapeBehavior));
		shapebehavior = (ShapeBehavior)Instantiate (original);
		shapebehavior.alto = alto;
		shapebehavior.ancho = ancho;
		shapebehavior.figure = createDebugFigure (alto,ancho); 
		shapebehavior.bloqueName = "EnemyBlock";
		invsnap = 1 / snapval;
		camera_height = transform.parent.camera.orthographicSize;
	}
	// Update is called once per frame
	void Update () {

		if (spawnReady) 
		{
			//Calcula la nueva posicion en base de la posicion del objeto, asegurandose que la 
			//posicion nueva este dentro de la camara
			if(shapebehavior.bloque != null)
			{
				Debug.LogError ("bloque no null");
				block_size = shapebehavior.bloque.renderer.bounds.size.y;
			}

			float new_y = transform.position.y + Random.Range(-camera_height+ancho*block_size,camera_height ); //Posicion parte desde el centro
			shapebehavior.x0 = Mathf.Round (transform.position.x*invsnap)/invsnap;
			shapebehavior.y0 = Mathf.Round (new_y*invsnap)/invsnap;  
			shapebehavior.InstantiateShape();
			spawnReady = false;
		}
	}
	
	//Crea una figura para propositos de testing y la asigna al shapebehavior
	FigureTemplate createDebugFigure(int alto, int ancho)
	{
		
		bool[,] figure = new bool[,]{
			{true,true,false,true},
			{true,true,true,true}
		};
		FigureTemplate figtemp = new FigureTemplate(figure,2,4);
		return figtemp;
		
	}
}
