using Core.Controller;
using UnityEngine;

public class StageInitializer : MonoBehaviour
{
    private StageController _stageController;
    private Monster[] _monsters;

    private void Start()
    {
        foreach(var monster in _monsters)
        {
            _stageController.RegisterMonster(monster);  
        }
    }
}