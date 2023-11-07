using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayQueue : MonoBehaviour
{
    public Stack<int> num= new Stack<int>();

    public Queue<int>nums = new Queue<int>();
    // Start is called before the first frame update
    void Start()
    {
       
        num.Push(5);
        num.Push(10);

        Debug.Log("count"+num.Count);

        Debug.Log("get value" + num.Peek());

        Debug.Log("remove" + num.Peek());
        Debug.Log("get stoke" + num.Peek());



       /* nums.Enqueue(5);
        nums.Enqueue(10);
        Debug.Log("get value" + nums.Peek());

        Debug.Log("get value" + nums.Dequeue());
        Debug.Log("get value" + nums.Dequeue());
       */
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
