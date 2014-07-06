using UnityEngine;
using System.Collections;

public class EnemySpawnBehavior : MonoBehaviour {

	public GameObject ShapeManager;
	private ShapeBehavior shapebehavior; 
	private int alto = 2;
	private int ancho = 4;
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
	}
	// Update is called once per frame
	void Update () {
		if (spawnReady) 
		{
			shapebehavior.x0 = Mathf.Round (transform.position.x*invsnap)/invsnap;
			shapebehavior.y0 = Mathf.Round (transform.position.y*invsnap)/invsnap;
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
