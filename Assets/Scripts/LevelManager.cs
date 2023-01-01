using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckpoint;

    private Player player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public int pointPenaltyOnDeath;

    public float respawnDelay;

	// Use this for initialization
	void Start ()
    {

        player = FindObjectOfType<Player>();

        Instantiate(respawnParticle, player.transform.position, player.transform.rotation);

    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.gameObject.SetActive(false);
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

}
