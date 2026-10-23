using UnityEngine;

public class CopanCancha : MonoBehaviour
{
    void Start()
    {
        var viejo = GameObject.Find("Juego_Pelota_Copan");
        if (viejo != null) Destroy(viejo);
        var viejoPuente = GameObject.Find("Puente_Cruce");
        if (viejoPuente != null) Destroy(viejoPuente);
        var viejoPiso = GameObject.Find("Piso_Extension_Copan");
        if (viejoPiso != null) Destroy(viejoPiso);

        var jp = new GameObject("Juego_Pelota_Copan");
        jp.transform.position = new Vector3(50, 0, 0);

        var piso = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piso.name = "Piso_Cancha";
        piso.transform.parent = jp.transform;
        piso.transform.localPosition = new Vector3(0, -0.1f, 0);
        piso.transform.localScale = new Vector3(10, 0.2f, 30);

        var ri = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ri.name = "Talud_Izq"; ri.transform.parent = jp.transform;
        ri.transform.localPosition = new Vector3(-7, 1, 0);
        ri.transform.localScale = new Vector3(4, 2, 28);
        ri.transform.localRotation = Quaternion.Euler(0, 0, -25);

        var bi = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bi.name = "Banqueta_Izq"; bi.transform.parent = jp.transform;
        bi.transform.localPosition = new Vector3(-10, 2, 0);
        bi.transform.localScale = new Vector3(3, 2, 32);

        var rd = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rd.name = "Talud_Der"; rd.transform.parent = jp.transform;
        rd.transform.localPosition = new Vector3(7, 1, 0);
        rd.transform.localScale = new Vector3(4, 2, 28);
        rd.transform.localRotation = Quaternion.Euler(0, 0, 25);

        var bd = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bd.name = "Banqueta_Der"; bd.transform.parent = jp.transform;
        bd.transform.localPosition = new Vector3(10, 2, 0);
        bd.transform.localScale = new Vector3(3, 2, 32);

        for (int i = -1; i <= 1; i++)
        {
            var t = GameObject.CreatePrimitive(PrimitiveType.Cube);
            t.name = "Templo_" + i; t.transform.parent = jp.transform;
            t.transform.localPosition = new Vector3(-10, 3.5f, i * 4);
            t.transform.localScale = new Vector3(2, 1.5f, 2.5f);
        }

        var a1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        a1.name = "Anillo_Izq"; a1.transform.parent = jp.transform;
        a1.transform.localPosition = new Vector3(-5, 1.5f, 0);
        a1.transform.localRotation = Quaternion.Euler(0, 0, 90);
        a1.transform.localScale = new Vector3(1, 0.15f, 1);

        var a2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        a2.name = "Anillo_Der"; a2.transform.parent = jp.transform;
        a2.transform.localPosition = new Vector3(5, 1.5f, 0);
        a2.transform.localRotation = Quaternion.Euler(0, 0, 90);
        a2.transform.localScale = new Vector3(1, 0.15f, 1);

        // PISO GIGANTE QUE UNE TODO - en vez de puente
        var extension = GameObject.CreatePrimitive(PrimitiveType.Cube);
        extension.name = "Piso_Extension_Copan";
        extension.transform.position = new Vector3(25, -1f, 0);
        extension.transform.localScale = new Vector3(70, 0.5f, 80);
        extension.GetComponent<Renderer>().material.color = new Color(0.76f, 0.71f, 0.55f);
    }
}
