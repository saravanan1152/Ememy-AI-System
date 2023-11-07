
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public enum AiMode
{

    // allAISAlart,
    allSiteCense,
    faceSiteCense,

}



[RequireComponent(typeof(NavMeshAgent))]
public class AlartAllAi : MonoBehaviour
{
    public Effect2 Effect;
    
    [Range(1f, 30f)]
    [SerializeField] float _censeDistance = 10;
    [Range(2f, 30f)]
    [SerializeField] float _attackDistance = 10;
    [Range(1f, 30f)]
    [SerializeField] float _aiStoppeingDistance = 8;
    [Range(1f, 180f)]
    [SerializeField] float angle = 30;
    [Range(-1f, 1f)]
    [SerializeField] float height = 1.0f;
    [Range(10f, 100f)]
    [SerializeField] int scanFrequncy = 30;
    [SerializeField] Color meahcolor = Color.red;
    [SerializeField] float _aiSpeed = 5;

    [Tooltip("Set Attack Object in tag")]
    [SerializeField] LayerMask layer;
    [Tooltip("Set the Default Layer in not Censer")]
    [SerializeField] LayerMask occlusionLayer;

    [SerializeField] List<GameObject> Objects = new List<GameObject>();
    Collider[] colliders = new Collider[50];
    Mesh mesh;
    int count;
    float scanInterval;
    float scanTimer;
    NavMeshAgent nav;
    bool Tarket;
    GameObject[] ais;

    [Tooltip("Target Object")]
    [SerializeField] Transform target;

    [Tooltip(" Set the Ai Mode")]
  
    [SerializeField] AiMode aiMode;
    [Tooltip("One enemy See the player then Alart all enemy follow player")]
    [SerializeField] bool allAISAlart;
    bool allSiteCense;
    bool faceSiteCense;
    float targetDistance;
    GameObject targetObject;

    // public EnemyAI enemyscript;


    /// <summary>
    /// Choices Add the Script with your need
    /// </summary>
    [Space(10)]
    [Header("Your choice")]
    //  [SerializeField] ProjectileAttack _attack;
  
   
    [SerializeField]public UnityEvent enterTheAttackDistance;
    [SerializeField] UnityEvent enterTheCenseingDistance;
    [SerializeField] UnityEvent enterTheStoppingDistace;
    // Start is called before the first frame update

    private void Awake()
    {
        if (aiMode == AiMode.faceSiteCense)
        {
            faceSiteCense = true;
            allSiteCense = false;
           
        }
        if (aiMode == AiMode.allSiteCense)
        {
            allSiteCense = true;
            faceSiteCense = false;
          

        }
    }
    void Start()
    {
        ais = GameObject.FindGameObjectsWithTag("Enemy");
        // _attack = GetComponent<ProjectileAttack>();
        scanInterval = 1.0f / scanFrequncy;
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = _aiStoppeingDistance;
        nav.speed = _aiSpeed;

        if (enterTheAttackDistance == null)
            enterTheAttackDistance = new UnityEvent();


    }

    // Update is called once per frame
    void Update()
    {


        scanTimer -= Time.deltaTime;
        if (scanTimer < 0)
        {
            scanTimer += scanInterval;
            Scan();
        }



        if (Tarket)
        {
            nav.SetDestination(target.position);
            transform.LookAt(target.position);
        }
    }
    private void Scan()
    {

        count = Physics.OverlapSphereNonAlloc(transform.position, _censeDistance, colliders, layer, QueryTriggerInteraction.Collide);

        Objects.Clear();
        for (int i = 0; i < count; ++i)
        {
            targetObject = colliders[i].gameObject;
            targetDistance = Vector3.Distance(targetObject.transform.position, transform.position);
            if (IsInSight(targetObject) && faceSiteCense)
            {
                Objects.Add(targetObject);
                if (allAISAlart)
                {
                    AttackAllAI();
                    AttackDistance();
                }

                nav.SetDestination(target.position);
                transform.LookAt(target.position);
                censeingDistance();
                AttackDistance();


                Debug.Log("enter");
                //  enemyscript.enabled = false;

            }


            if (allSiteCense)
            {
                RoundDistace();
                AttackDistance();
            }

            StoppingDistance();
        }




    }


    void censeingDistance()
    {
        if (targetDistance < _censeDistance)
        {
            Debug.Log("cense");
            enterTheCenseingDistance.Invoke();
        }
    }
    void AttackDistance()
    {

        if (targetDistance < _attackDistance)
        {
            Debug.Log("Attack");
            // _attack.Active = true;
            enterTheAttackDistance.Invoke();
        }
        else
        {
            // _attack.Active= false;
        }
    }
    void StoppingDistance()
    {
        if (targetDistance < _aiStoppeingDistance)
        {
            Debug.Log("Stop");
            enterTheStoppingDistace.Invoke();
        }

    }
    void AttackAllAI()
    {
        foreach (GameObject ai in ais)
        {
            AlartAllAi allAI = ai.GetComponent<AlartAllAi>();

            allAI.Tarket = true;
        }
    }
    void RoundDistace()
    {
        nav.SetDestination(target.position);
        transform.LookAt(target.position);

        if (allAISAlart)
        {
            AttackAllAI();
        }
    }

    public bool IsInSight(GameObject obj)
    {
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;
        if (direction.y < 0 || direction.y > height)
        {
            return false;
        }
        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);
        if (deltaAngle > angle)
        {
            return false;
        }
        origin.y += height / 2;
        dest.y = origin.y;
        if (Physics.Linecast(origin, dest, occlusionLayer))
        {
            return false;
        }
        return true;
    }
    Mesh CreateWedgeMash()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numTriangles = (segments * 4) + 2 + 2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * _censeDistance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * _censeDistance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;

        int vert = 0;
        //left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //rtight side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -angle;
        float delteAngle = (angle * 2) / segments;
        for (int i = 0; i < segments; i++)
        {

            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * _censeDistance;
            bottomRight = Quaternion.Euler(0, currentAngle + delteAngle, 0) * Vector3.forward * _censeDistance;


            topRight = bottomRight + Vector3.up * height;
            topLeft = bottomLeft + Vector3.up * height;

            //far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;

            //top
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            //bottom
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += delteAngle;
        }


        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;

        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
    private void OnValidate()
    {
        mesh = CreateWedgeMash();
    }

    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = meahcolor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);

        }
        Gizmos.DrawWireSphere(transform.position, _censeDistance);

        Gizmos.color = Color.red;
        for (int i = 0; i < count; ++i)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }


        Gizmos.color = Color.black;

        foreach (var obj in Objects)
        {

            Gizmos.DrawWireSphere(obj.transform.position, 0.5f);
        }


        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _attackDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _aiStoppeingDistance);


    }





}
