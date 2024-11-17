using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int loadSceneIndex;
    [SerializeField] private int UnloadSceneIndex;
    private GameObject targetPlayer;

    private class LoadingMonoBehaviour : MonoBehaviour { }

    [SerializeField] private Vector3 changeTransform;
    [SerializeField] private Quaternion changeRotation;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                //execSceneChange();
                StartCoroutine(changeScene());
            }
            Debug.Log("Change Scene");
        }

    }

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    void execSceneChange()
    {


    }
    IEnumerator changeScene()
    {
        //SceneManager.UnloadSceneAsync(UnloadSceneIndex);
        //yield return null;
        targetPlayer.GetComponent<CharacterController>().enabled = false;
        yield return null;
        targetPlayer.transform.position = new Vector3(changeTransform.x, changeTransform.y, changeTransform.z);
        //targetPlayer.transform.rotation = new Quaternion(0, changeRotation.x, changeRotation.y, changeRotation.z);
        yield return null;
        targetPlayer.GetComponent<CharacterController>().enabled = true;
        yield return null;
        SceneManager.LoadSceneAsync(loadSceneIndex);
        yield return null;
        SceneManager.UnloadSceneAsync(UnloadSceneIndex);
        //Destroy(gameObject);
    }
    public void ChangeSceneBehaviour()
    {
        SceneManager.LoadScene(loadSceneIndex);
    }
}