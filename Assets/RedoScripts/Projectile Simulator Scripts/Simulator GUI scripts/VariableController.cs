using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PhysicsProjectileSimulator
{
    public class VariableController : PhysicsSimulator
    {
        public TMP_Text ErrorMessageText;
        [SerializeField] private GameObject HideVariableButton1;
        [SerializeField] private GameObject HideVariableButton2;

        public SuvatDropdownController SuvatDropdownController;
        public SuvatInputFieldController SuvatInputFieldController;
        public MissingSuvatTextController missingSuvatTextController;
        public FindMissingSuvat findMissingSuvat;

        [SerializeField] public List<GameObject> spawnInputsPrefabList;
        // conatins at start: Initial velocity, Final velocity, Displacement
        public List<string> selectedVariables;
        // conatins at start: Accleration, Time
        public List<string> unselectedVariables;

        public Vector3 displacement;
        public Vector3 initialVelocity;
        public Vector3 finalVelocity;
        public Vector3 acceleration;
        public Vector3 time;

        private bool acceptInputs = true;
        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateInputtedVariables()
        {
            foreach (string var in selectedVariables)
            {
                int index = selectedVariables.IndexOf(var);
                if (var == "Displacement")
                {
                    displacement = SetVariableVector3(index);
                }
                else if (var == "Initial Velocity")
                {
                    initialVelocity = SetVariableVector3(index);
                }
                else if (var == "Final Velocity")
                {
                    finalVelocity = SetVariableVector3(index);
                }
                else if (var == "Acceleration")
                {
                    acceleration = SetVariableSingle(index);

                }
                else if (var == "Time")
                {
                    time = SetVariableSingle(index);
                }

            }

            foreach (string var in selectedVariables)
            {
                if (var == "Displacement")
                {
                    if (CheckVariableInRange(displacement.x, 3, 50) == false || CheckVariableInRange(displacement.y, 1, 50) == false || CheckVariableInRange(displacement.z, -50, 50) == false)
                    {
                        // if one of the displacement components are not it in specified variables don't accept input
                        acceptInputs = false;
                        ErrorMessageText.text = "Displacement needs to be in the range of:                       X:(3 - 50) Y:(1-50) Z:(-50 - 50)";
                    }
                }
                else if (var == "Initial Velocity")
                {
                    if (CheckVariableInRange(initialVelocity.x, 1, 50) == false || CheckVariableInRange(initialVelocity.y, 0, 50) == false || CheckVariableInRange(initialVelocity.z, -50, 50) == false)
                    {
                        // if one of the initialVelocity components are not it in specified variables don't accept input
                        acceptInputs = false;
                        ErrorMessageText.text = "Initial Velocity needs to be in the range of:                   X:(3 - 50) Y:(1-50) Z:(-50 - 50)";
                    }
                }
                else if (var == "Final Velocity")
                {
                    if (CheckVariableInRange(finalVelocity.x, -50, 50) == false || CheckVariableInRange(finalVelocity.y, -50, 50) == false || CheckVariableInRange(finalVelocity.z, -50, 50) == false)
                    {
                        // if one of the finalVelocity components are not it in specified variables don't accept input
                        acceptInputs = false;
                        ErrorMessageText.text = "Final Velocity needs to be in the range of:                     X:(3 - 50) Y:(1-50) Z:(-50 - 50)";
                    }
                }
                else if (var == "Acceleration")
                {
                    if (CheckVariableInRange(acceleration.x, -20, 20) == false)
                    {
                        // if one of the acceleration components are not it in specified variables don't accept input
                        acceptInputs = false;
                        ErrorMessageText.text = "Acceleration needs to be in the range of:                       Y:(1-50)";
                    }
                }
                else if (var == "Time")
                {
                    if (CheckVariableInRange(time.x, 0, 50) == false)
                    {
                        // if one of the time components are not it in specified variables don't accept input
                        acceptInputs = false;
                        ErrorMessageText.text = "Time needs to be in the range of:                               Y:(1-50)";
                    }
                }

            }

            if (acceptInputs == true)
            {
                foreach (string var in selectedVariables)
                {
                    int index = selectedVariables.IndexOf(var);
                    if (var == "Displacement")
                    {
                        displacement = SetVariableVector3(index);
                        Debug.Log("s");
                    }

                    if (var == "Initial Velocity")
                    {
                        initialVelocity = SetVariableVector3(index);
                        Debug.Log("u");
                    }
                    if (var == "Final Velocity")
                    {
                        finalVelocity = SetVariableVector3(index);
                        Debug.Log("v");
                    }
                    if (var == "Acceleration")
                    {
                        acceleration = SetVariableSingle(index);
                        acceleration.x = 0.0f;
                        acceleration.z = 0.0f;
                        Debug.Log("a");

                    }
                    if (var == "Time")
                    {
                        time = SetVariableSingle(index);
                        Debug.Log("t");
                    }
                }
                ErrorMessageText.text = "Successfull Input";
                missingSuvatTextController.UpdateAllText();
                ResetHideButtons();
            }
            else
            {
                acceptInputs = true;
            }



        }

        private Vector3 SetVariableVector3(int index)
        {
            GameObject parentObject = spawnInputsPrefabList[index];

            TMP_InputField[] inputFields = parentObject.GetComponentsInChildren<TMP_InputField>();

            // Access the text of each InputField
            float inputText1 = float.Parse(inputFields[0].text);
            float inputText2 = float.Parse(inputFields[1].text);
            float inputText3 = float.Parse(inputFields[2].text);



            return new Vector3(inputText1, inputText2, inputText3);
        }

        private Vector3 SetVariableSingle(int index)
        {
            GameObject parentObject = spawnInputsPrefabList[index];

            TMP_InputField[] inputFields = parentObject.GetComponentsInChildren<TMP_InputField>();
            float inputText = float.Parse(inputFields[0].text);
            return new Vector3(inputText, inputText, inputText);

        }

        private bool CheckVariableInRange(float varComponent, float lowRange, float highRange)
        {
            if (varComponent >= lowRange && varComponent <= highRange)
            {
                return true;
            }
            return false;
        }

        private void ResetHideButtons()
        {
            HideVariableButton1.SetActive(true);
            HideVariableButton2.SetActive(true);
        }
    }

}
