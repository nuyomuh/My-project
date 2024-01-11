using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform takipEdilecekNesne;
    public float yumusatmaDegeri = 10f;

    void LateUpdate()
    {
        if (takipEdilecekNesne != null)
        {
            Vector3 hedefPozisyon = new Vector3(takipEdilecekNesne.position.x, takipEdilecekNesne.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, hedefPozisyon, yumusatmaDegeri * Time.deltaTime);
        }
    }
}
