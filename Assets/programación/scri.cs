using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingenemy : MonoBehaviour
{
    [SerializeField] GameObject player;

    BoxCollider2D myCollider;
    [SerializeField] float fireRate;
    [SerializeField] private Transform cañon;
    [SerializeField] GameObject BalaCañon;
    [SerializeField] GameObject explosión;
    [SerializeField] private Transform puntoA;
    [SerializeField] private Transform puntoB;
    [SerializeField] GameObject Cuerpo;
    [SerializeField] public float vida;
    [SerializeField] GameManager gm;
    public float daño = 1;
    int conteoDeDaño;
    float nextFire = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void chaseplayer()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, 8f, LayerMask.GetMask("player"));
        if (col != null)
        {
            Debug.Log("persiguiendo");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 8f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;

        string bala = objeto.tag;

        if (objeto.tag == "bala")
        {
            conteoDeDaño++;

            if (conteoDeDaño == vida)
            {
                //bee_animator.SetTrigger("Destroy");
                muerte();
                Destroy(GetComponent<CircleCollider2D>());
                Destroy(gameObject, 1f);

            }

        }
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            muerte();
        }
    }

    void muerte()
    {
        Instantiate(explosión, puntoA.transform.position, puntoA.rotation);
        Instantiate(Cuerpo, puntoB.transform.position, puntoB.rotation);
        Destroy(this.gameObject);
    }



}
