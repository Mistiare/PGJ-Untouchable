using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField]
    private int id = 0;
    [SerializeField]
    private bool isVoice = false;
    [SerializeField]
    private bool isEnemy = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (isEnemy)
            {
                GameEvents.current.EnemyTriggerEnter(id);
            }
            if (isVoice)
            {
                GameEvents.current.VoiceTriggerEnter(id);
            }
        }
    }
}
