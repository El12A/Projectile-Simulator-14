using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PhysicsProjectileSimulator
{
    public class MoveTarget : VariableController
    {
        public void OnDisplacementChange()
        {
            if (ErrorMessageText.text == "Successfull Input")
            {
                transform.position = projectile.initialPosition + variableController.displacement;
            }
        }
    }
}

