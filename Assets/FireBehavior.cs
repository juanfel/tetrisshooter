using UnityEngine;
using System.Collections;

public class FireBehavior : MonoBehaviour {
	public GameObject ShapeManager;
	private ShapeBehavior shapebehavior; 
	private int alto = 2;
	private int ancho = 4;
	private float snapval = 1f; //Para que aproxime a una posicion en intervalos de 1.5 (1.46->1.5)
	private float invsnap;
	FigureTemplate[] figures;
	// Use this for initialization
	void Start () {
		shapebehavior = (ShapeBehavior)ShapeManager.GetComponent(typeof(ShapeBehavior));
		shapebehavior.alto = alto;
		shapebehavior.ancho = ancho;
		shapebehavior.bloqueName = "BlockSprite";
		invsnap = 1 / snapval;
		figures = createDebugFigures ();

	}
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1") == true) 
		{
			shapebehavior.figure = figures[Random.Range (0,3)];
			shapebehavior.x0 = Mathf.Round (transform.position.x*invsnap)/invsnap;
			shapebehavior.y0 = Mathf.Round (transform.position.y*invsnap)/invsnap;
			shapebehavior.InstantiateShape ();

		}
		if (Input.GetButtonDown ("Fire2") == true) 
		{
			shapebehavior.figure.rotate();
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
