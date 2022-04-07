using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    [SerializeField] private Transform[] allBoxes;

    [SerializeField] private Transform[] allNumberBoxes;
    [SerializeField] private Transform[] powerBoxes;
    [SerializeField] private Transform[] dirBoxes;

    public Transform[] GetAllBoxes(){
        return allBoxes;
    }

    public Transform[] GetAllNumberBoxes(){
        return allNumberBoxes;
    }

    public Transform GetNumberBox(int i){
        return allNumberBoxes[i];
    }
    public Transform GetPowerBox(int i){
        return powerBoxes[i];
    }

    public Transform GetDirectionBox(int i){
        return dirBoxes[i];
    }

    public Box GetBoxWithSamePositionValue(Vector3 value){
        foreach (Transform box in allBoxes)
        {
            if(box.position == value){
                return box.GetComponent<Box>();
            }
        }

        return null;
    }
}
