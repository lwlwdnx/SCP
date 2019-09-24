using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchRange : MonoBehaviour {

    [SerializeField] private List<GameObject> enemy_list = new List<GameObject>();
    [SerializeField] private GameObject manage;

    // Use this for initialization
    void Start ()
    {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (manage.GetComponent<SCPManager>().battery_light_flag && other.GetComponent<Enemy>().enemy_state != Enemy.EnemyState.STUN)
            {
                manage.GetComponent<SCPManager>().SetLightPosition(manage.GetComponent<SCPManager>().batteryManagerScript.nowTransform.position);
                manage.GetComponent<SCPManager>().ChangeEnemyMode(other.GetComponent<Enemy>(),Enemy.EnemyState.CHASE);
            }
        }
    }
}
