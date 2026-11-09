using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour {

  bool comecou;
  bool acabou;
  Rigidbody2D corpoJogador;
  Vector2 forcaImpulso = new Vector2(0, 100f);
  public ProjectileBehaviour ProjectilePrefab;
  public Transform LaunchOffset;
  private int countHP;
  public TextMeshProUGUI countHPText;
 

    void Start () {
        corpoJogador = GetComponent<Rigidbody2D>();
        countHP = 3;
        Time.timeScale = 1f;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {

            if (!comecou)
            {
                comecou = true;
            }

            corpoJogador.linearVelocity = new Vector2(0, 0);
            corpoJogador.AddForce(forcaImpulso);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }

        SetCountText();
        
    }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Inimigo" || other.gameObject.tag == "UrucaBullet")
            {
                countHP = countHP - 1;
                other.gameObject.SetActive(false);
            }
        SetCountText();

        }

        public GameObject GameOver;

    void SetCountText()
        {
        countHPText.text = "VIDAS: " + countHP.ToString();

            if (countHP <= 0)
            {
            GameOver.SetActive(true);
            Time.timeScale = 0f;
            }
        }
    }
