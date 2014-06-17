using UnityEngine;
using System.Collections;

public class FireBehavior : MonoBehaviour {
	public GameObject ShapeManager;
	private ShapeBehavior shapebehavior; 
	private int alto = 2;
	private int ancho = 4;
	bool[][] figure;
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
	}

	//Crea una figura para propositos de testing y la asigna al shapebehavior
	bool[][] createDebugFigure(int alto, int ancho)
	{
		bool[][] figure = new bool[alto][];
		for (int i = 0; i<alto; i++)
		{
			figure[i] = new bool[ancho];
		}
		figure[0]=new bool[]{true,true,false,true};
		figure[1]=new bool[]{true,true,true,true};
		return figure;

	}
}
