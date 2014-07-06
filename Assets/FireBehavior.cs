﻿using UnityEngine;
using System.Collections;

public class FireBehavior : MonoBehaviour {
	public GameObject ShapeManager;
	private ShapeBehavior shapebehavior; 
	private int alto = 2;
	private int ancho = 4;
	private float snapval = 1f; //Para que aproxime a una posicion en intervalos de 1.5 (1.46->1.5)
	private float invsnap;
	FigureTemplate figure;
	// Use this for initialization
	void Start () {
		shapebehavior = (ShapeBehavior)ShapeManager.GetComponent(typeof(ShapeBehavior));
		shapebehavior.alto = alto;
		shapebehavior.ancho = ancho;
		shapebehavior.figure = createDebugFigure (alto,ancho); 
		shapebehavior.bloqueName = "BlockSprite";
		invsnap = 1 / snapval;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") == true) 
		{
			shapebehavior.x0 = Mathf.Round (transform.position.x*invsnap)/invsnap;
			shapebehavior.y0 = Mathf.Round (transform.position.y*invsnap)/invsnap;
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
