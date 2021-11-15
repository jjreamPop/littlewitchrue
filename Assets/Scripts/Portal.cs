using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneTarget;
    public GameObject player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            StartCoroutine(startNextScene());
        }
    }

    IEnumerator startNextScene()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneTarget, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Scene nextScene = SceneManager.GetSceneByName(sceneTarget);
        
        // Get the next portal and player GameObjects
        GameObject[] nextRootObjects = nextScene.GetRootGameObjects();
        GameObject nextPortal = null;
        GameObject nextPlayer = null;
        foreach(GameObject go in nextRootObjects)
        {
            if (go.tag == "portal")
            {
                nextPortal = go;
            } else if (go.tag == "Player")
            {
                nextPlayer = go;
            }
        }
        if (nextPortal == null)
        {
            throw new System.Exception();
        }

        // Remove the next player
        if (nextPlayer != null)
        {
            Debug.Log("Destroying Player");
            Destroy(nextPlayer);
        }

        // Set the next portal as inactive
        nextPortal.SetActive(false);

        // Set the portal's player to our player
        Portal nextPortalScript = nextPortal.GetComponent(typeof(Portal)) as Portal;
        nextPortalScript.player = player;

        // Reset our player's WaitForClear with new portal GameObject
        WaitForClear nextWFC = player.GetComponent(typeof(WaitForClear)) as WaitForClear;
        nextWFC.portal = nextPortal;

        // Detach our player from any parents
        player.transform.parent = null;

        // Move player and unload
        Debug.Log("Preparing to move Rue");
        while (!playerHasMoved(nextScene))
        {
            Debug.Log("Moving Rue to " + sceneTarget);
            SceneManager.MoveGameObjectToScene(player, nextScene);
        }

        Vector3 pos = new Vector3(-5, -3.5f);
        player.transform.position = pos;
        SceneManager.UnloadSceneAsync(currentScene);
    }

    bool playerHasMoved(Scene nextScene)
    {
        Debug.Log("Checking if Rue has moved");
        GameObject[] nextRootObjects = nextScene.GetRootGameObjects();
        foreach (GameObject go in nextRootObjects)
        {
            if (go.tag == "Player")
            {
                Debug.Log("Rue found");
                return true ;
            }
        }
        return false;
    }
}
