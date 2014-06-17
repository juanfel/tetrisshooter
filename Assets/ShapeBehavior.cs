using UnityEngine;
using System.Collections;
//Esta clase instancia una figura en el espacio y hace que cada bloque avance ocupando
//su patron de movimiento
public class ShapeBehavior : MonoBehaviour {
	public string bloqueName; //Nombre del bloque a instanciar
	public GameObject bloque;	//Aqui va el tipo de bloque que queremos usar para el shape 
	public bool[][] figure;   //Aqui va la figura, que es instanciada en otra parte
								//1-> hay bloque en esa posicion. 0-> no hay bloque
	public int ancho;
	public int alto;

	public float x0;
	public float y0;

	// Reemplaza los valores donde deben ir los bloques por los bloques mismos
	// Ademas los instancia en el mundo. Parte desde el extremo (0,0). O sea, va rellenando
	// al reve
	public void StartShape () {
		float x = x0;
		float y = y0;
		bloque = (GameObject)Resources.Load (bloqueName);
		/*for (int i = 0; i < alto; i++) {
			for (int j = 0; j < ancho; j++) {
				if(figure[i][j] == true)
				{
					Instantiate(bloque,new Vector3(x,y,0),Quaternion.identity);
				}

				y -= 1;
			}
			y = y0;

			x += 1;
		}*/
		foreach (bool[] i in figure) {
			foreach(bool j in i)
			{
				if(j == true)
				{
					Instantiate(bloque,new Vector3(x,y,0),Quaternion.identity);
				}
				//y -= bloque.collider2D.bounds.size.y;
				y -=1;
			}
			y = y0;
			//x += bloque.collider2D.bounds.size.x;
			x += 1;
		}

	}

	// Update is called once per frame
	void Update () {
		
	}
}
