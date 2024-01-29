using UnityEngine;

public class AllyMovementAndStates : MonoBehaviour
{
    Attack attack;
    public Animator Anim;

    public float Speed;
    public float MoveDistance;//Önündekini algýlayýp duracaðý mesafe

    public GameObject Enemy;
    public GameObject Ally;

    public bool Attack;
    public bool Run;

    private void Start()
    {
        attack = GetComponentInChildren<Attack>();
    }

    private void FixedUpdate()
    {
        CheckForward();
    }

    private void Update()
    {

        if (Run)
        {
            this.transform.position += Vector3.forward * Speed * Time.deltaTime;
        }
        else if (Attack && Enemy!=null)
        {
            attack.Fire(Enemy);
        }
        if (Enemy == null)
        {
            Attack = false;
        }
    }

    void CheckForward()
    {
        Vector3 raycastPos = this.transform.position;

        Vector3 rayDirection = this.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(raycastPos, rayDirection, out hit, MoveDistance))
        {
            if (hit.collider.CompareTag("Ally"))
            {
                Transform ally = hit.transform;
                GameObject allyGameObject = ally.transform.gameObject;
                // Ray'i görselleþtir
                Debug.DrawRay(raycastPos, rayDirection * hit.distance, Color.red);
                Ally = allyGameObject;
                Run = false;
                Anim.SetBool("isRunning", false);
            }
            else
            {
                Ally = null;
                Run = true;
                Anim.SetBool("isRunning", true);
            }
        }
        else
        {
            Debug.DrawRay(raycastPos, rayDirection * MoveDistance, Color.green);
            Ally = null;
            Run = true;
            Anim.SetBool("isRunning", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(Enemy == null)
            {
                Enemy = other.gameObject;
                Attack = true;
                Run = false;
                Anim.SetBool("isRunning", false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Attack = true;
            Run = false;
            Anim.SetBool("isRunning", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Attack = false;
            Enemy = null;
            Run = true;
            Anim.SetBool("isRunning", true);
        }
    }


}
