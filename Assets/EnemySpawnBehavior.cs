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
	FigureTemplate[] figures;
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
		shapebehavior.bloqueName = "EnemyBlock";
		invsnap = 1 / snapval;
		camera_height = transform.parent.camera.orthographicSize;
		figures = createDebugFigures ();
	}
	// Update is called once per frame
	void Update () {

		if (spawnReady) 
		{
			//Calcula la nueva posicion en base de la posicion del objeto, asegurandose que la 
			//posicion nueva este dentro de la camara
			shapebehavior.figure = figures[Random.Range (0,3)];
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
	bool[,] figure;
	//Crea una figura para propositos de testing y la asigna al shapebehavior
	FigureTemplate createDebugFigure(int alto, int ancho,int tipo)
	{
		
		if(tipo == 1)
		{
			figure = new bool[,]{
				{true,true,false,true},
				{true,true,true,true}
			};
			
		}
		if(tipo == 2)
		{
			figure = new bool[,]{
				{false,true,false,false},
				{true,true,true,true}
			};
			
		}
		if(tipo == 3)
		{
			figure = new bool[,]{
				{true,true,true,true},
				{true,false,false,true}
			};
			
		}
		
		FigureTemplate figtemp = new FigureTemplate(figure,2,4);
		return figtemp;
	}
	FigureTemplate[] createDebugFigures()
	{
		FigureTemplate[] figures = new FigureTemplate[3];
		for (int i = 0; i <= 2; i++) 
		{
			figures[i] = createDebugFigure (2,4,i+1);
		}
		return figures;
	}
}
