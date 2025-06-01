using UnityEngine;

public class ParalaxVertical : MonoBehaviour
{
    public Transform camera;
    public float altura;
    public Transform[] fondos;
    [SerializeField] private bool Direction = false;

   
    void Update()
    {
       foreach(Transform fondo in fondos)
        {
            if (Direction)
            {

                if (camera.position.y < fondo.position.y - altura / fondos.Length)
                {
                    float nuevay = fondo.position.y - altura;
                    fondo.position = new Vector3(fondo.position.x, nuevay, fondo.position.z);
                }
            }

            else
            {
                if (camera.position.y > fondo.position.y + altura / fondos.Length)
                {
                    float nuevay = fondo.position.y + altura;
                    fondo.position = new Vector3(fondo.position.x, nuevay, fondo.position.z);
                }
            }
        }
    }

    void Esperar()
    {

    }
}
