using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject charObj;
    private int currentBoxNumber = -1;

    private Vector2 defaultPos;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToBox(Vector2 value, int currentBoxNumber){
        charObj.transform.position = value;
        this.currentBoxNumber = currentBoxNumber;
    }

    public void MoveToDefaultPos(){
        transform.position = defaultPos;
        this.currentBoxNumber = -1;
    }

    public int GetCurrentBoxNumber(){
        return this.currentBoxNumber;
    }
}
