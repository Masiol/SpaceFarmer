using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarmBehaviour
{
    FarmInfo FarmProduceInformations();
    void StartProcess();
    void SpawnElements();
    void FloatingToPoint(Transform T);

    
}
