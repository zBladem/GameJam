using UnityEngine;

public class ParalaxVertical : MonoBehaviour
{
    public Transform camera;
    public float altura;
    public Transform[] fondos;

   
    void Update()
    {
       foreach(Transform fondo in fondos)
        {
            if (camera.position.y > fondo.position.y+altura/fondos.Length)
            {
                float nuevay = fondo.position.y + altura;
                fondo.position=new Vector3(fondo.position.x,nuevay,fondo.position.z);
            }
        }
    }

    void Esperar()
    {

    }
}
