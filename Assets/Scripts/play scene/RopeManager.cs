using UnityEngine;

public class RopeManager : MonoBehaviour
{
    [SerializeField] private GameObject ropeObject;

    [SerializeField] private GameObject ropeTarget;

    MonoBehaviour[] scripts;

    private void Awake()
    {
        scripts = GetComponentsInChildren<MonoBehaviour>(true);
        Pause();
    }

    public void Reset()
    {
        ropeObject.transform.position = Vector2.zero;
        ropeTarget.transform.position = Vector2.zero;
    }

    public void Pause(){
        foreach (MonoBehaviour script in scripts){
            script.enabled = false;
        }
    }

    public void Play(){
                foreach (MonoBehaviour script in scripts){
            script.enabled = true;
        }
    }
}
