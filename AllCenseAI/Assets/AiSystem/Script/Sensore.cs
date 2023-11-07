using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[ExecuteInEditMode]
[RequireComponent(typeof(NavMeshAgent))]
public class Sensore : MonoBehaviour
{
    [Range(1f, 30f)]
    public float distance = 10;
    [Range(1f,180f)]
    public float angle = 30;
    [Range(-1f,1f)]
    public float height = 1.0f;
    [Range(10f,100f)]
    public int scanFrequncy = 30;
    public Color meahcolor = Color.red;
    [SerializeField] float _speed = 5;
    [Tooltip("Set Attack Object in tag")]
    public LayerMask layer;
    [Tooltip("Set the Default Layer in not Censer")]
   public LayerMask occlusionLayer;
    public List<GameObject> Objects = new List<GameObject>();

    Collider[] colliders = new Collider[50];
    Mesh mesh;
    int count;
    float scanInterval;
    float scanTimer;

    NavMeshAgent nav;
    [Tooltip("Target Object")]
   [SerializeField] Transform Player;

  // public EnemyAI enemyscript;


    /// <summary>
    /// Choices Add the Script with your need
    /// </summary>
    [SerializeField] ProjectileAttack _attack;
    // Start is called before the first frame update
    void Start()
    {
        scanInterval = 1.0f / scanFrequncy;
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance =2;
        nav.speed =_speed;
     
        
    }

    // Update is called once per frame
    void Update()
    {
        scanTimer -= Time.deltaTime;
        if (scanTimer<0)
        {
            scanTimer += scanInterval;
            Scan();
        }
    }
    private void Scan()
    {

        count = Physics.OverlapSphereNonAlloc(transform.position, distance, colliders, layer, QueryTriggerInteraction.Collide);
        Objects.Clear();
        for (int i=0;i<count;++i)
        {
            GameObject obj = colliders[i].gameObject;
            if (IsInSight(obj))
            {
              
                Objects.Add(obj);

                nav.SetDestination(Player.position);
                transform.LookAt(Player.position);
                _attack.Active = true;
                Debug.Log("enter");
              //  enemyscript.enabled = false;

            }
            else
            {
                Debug.Log("valila");
                _attack.Active = false; 
            }
          
           
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
        if (Physics.Linecast(origin, dest,occlusionLayer))
        {
            return false;
        }
        return true;
    }
    Mesh CreateWedgeMash()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numTriangles = (segments*4)+2+2;
        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

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
        for(int i = 0; i < segments; i++)
        {

             bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance;
             bottomRight = Quaternion.Euler(0, currentAngle+delteAngle, 0) * Vector3.forward * distance;

           
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
        Gizmos.DrawWireSphere( transform.position, distance);

        Gizmos.color= Color.red;
        for(int i = 0; i < count; ++i)
        {
            Gizmos.DrawSphere(colliders[i].transform.position, 0.2f);
        }
       
      
        Gizmos.color = Color.black;
        
        foreach(var obj in Objects)
        {
           
            Gizmos.DrawWireSphere(obj.transform.position, 0.5f);
        }
    }
  

}
