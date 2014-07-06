using UnityEngine;
using System.Collections;

public class FireBehavior : MonoBehaviour {
	public GameObject ShapeManager;
	private ShapeBehavior shapebehavior; 
	private int alto = 2;
	private int ancho = 4;
	FigureTemplate figure;
	// Use this for initialization
	void Start () {
		shapebehavior = (ShapeBehavior)ShapeManager.GetComponent(typeof(ShapeBehavior));
		shapebehavior.alto = alto;
		shapebehavior.ancho = ancho;
		shapebehavior.figure = createDebugFigure (alto,ancho); 
		shapebehavior.bloqueName = "SmallBlockSprite";

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") == true) 
		{
			shapebehavior.x0 = transform.position.x;
			shapebehavior.y0 = transform.position.y;
			shapebehavior.StartShape();
		}
		if (Input.GetButtonDown ("Fire2") == true) 
		{
			shapebehavior.figure.rotate();
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
