using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject charObj;
    [SerializeField] int currentBoxNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToBox(Vector2 value, int skippedNumber = 0){
        charObj.transform.position = value;
        this.currentBoxNumber += skippedNumber + 1;
    }

    public int GetCurrentBoxNumber(){
        return this.currentBoxNumber;
    }
}
