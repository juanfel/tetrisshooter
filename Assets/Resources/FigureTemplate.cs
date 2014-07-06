using UnityEngine;
using System.Collections;

public class FigureTemplate
{
	public int size_x; //Tamaño de la figura mas grande
	public int size_y;
	public bool[,] figure;
	
	public FigureTemplate(bool[,] figure,int size_x, int size_y)
	{
		this.figure = figure;
		this.size_x = size_x;
		this.size_y = size_y;
	}
	public void rotate()
	{
		//Crea una matriz nueva con la figura rotada, y la deja como figura actual
		//Es necesario que la matriz nueva tenga el tamaño rotado (nxm -> mxn)
		bool[,] matrix = new bool[size_y, size_x];
		for (int i = 0; i < size_x; ++i) {
			for (int j = 0; j < size_y; ++j) {
				matrix[j, i] = figure[size_x - i - 1,j];
			}
		}
		int temp = size_x;
		size_x = size_y;
		size_y = temp; 
		figure = matrix;
	}
}