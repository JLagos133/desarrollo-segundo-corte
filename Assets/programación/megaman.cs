using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaman : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    [SerializeField] BoxCollider2D misPies;
    [SerializeField] float fireRate;
    [SerializeField] GameObject Bala;
    [SerializeField] GameObject Bala2;
    [SerializeField] private Transform disparador;
    [SerializeField] public float vida;
    Animator MyAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;
    float movH;
    float nextFire = 0;
    public float daño = 1;
    int direccionImpulso=1;
    public bool ani;

    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = GetComponent<Animator>();
        MyAnimator.SetBool("isrunning", false);
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        ani = true;
    }

    // Update is called once per frame
    void Update()
    {
        correr();
        caer();
        Disparar();
        salto();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("balaE"))
        {
            vida -= daño;
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }


        }
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void Disparar()
    {

        if (Input.GetKeyDown(KeyCode.W) && Time.time >= nextFire)
        {
            
            MyAnimator.SetLayerWeight(1, 1);

            Instantiate(Bala, disparador.transform.position, disparador.rotation);
            nextFire = Time.time + fireRate;
            
        }
        else if(ani == false)
        {
            
            MyAnimator.SetLayerWeight(1, 0);
         
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            Invoke("brazo", 2.1f);
            Invoke("brazo2", 2f);
        }

    }

    void brazo()
    {
            ani = true;
    }

    void brazo2()
    {
        ani = false;
    }

    void caer()
    {
        if(myBody.velocity.y<0)
        {
            MyAnimator.SetBool("falling", true);
        }
        else
        {
            MyAnimator.SetBool("falling", false);
        }
    }
    bool suelo()
    {
        return misPies.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void salto()
    {
        if (suelo())
        {
            MyAnimator.SetBool("falling", true);
            if (Input.GetKeyDown(KeyCode.K))
            {
                myBody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                MyAnimator.SetTrigger("jumping");
                
            }
            else
                MyAnimator.SetBool("falling", false);
        }
}

    

    public void correr()
    {
        float direccion = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(direccion * Time.deltaTime * speed, 0));

        if (direccion != 0)
        {
            if (direccion < 0)
            {
                transform.localScale = new Vector2(-1, 1);
                //transform.eulerAngles = new Vector3(0, 180, 0);
                direccionImpulso = -1;
            }
            
            if(direccion > 0)
            { 
                transform.localScale = new Vector3(1, 1);
                //transform.eulerAngles = new Vector3(0, 180, 0);
                direccionImpulso = 1;
            }
                
                

            MyAnimator.SetBool("isrunning", true);
        }
        else
            MyAnimator.SetBool("isrunning", false);

        transform.Translate(new Vector2(direccion * Time.deltaTime * speed, 0));
    }

   
    }

    
   

