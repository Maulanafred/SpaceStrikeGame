using UnityEngine;

public class BossDeadCutScene : MonoBehaviour
{
    public Transform boss; // Transform pemain
 
    private void Start(){

    }



    private void Update()
    {

        transform.position = boss.position;


    }

}