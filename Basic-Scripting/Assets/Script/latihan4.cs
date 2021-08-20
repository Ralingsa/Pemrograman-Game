using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latihan4 : MonoBehaviour
{
    Karakter player1;
    // use this for initialization
    private void Start()
    {
        player1 = new Karakter();
        player1.Name = "Dico";
        player1.Health = 100;
        player1.Damage = 30;
        // menampilkan hasil dari inisialisasi atribute
        Debug.Log("Name: " + player1.Name + ", Health: " 
            + player1.Health + ", Damage: " + player1.Damage);
        // memanggil method dari salah satu method di class karakter

        player1.jump();
    }

    // update called once per frame
    private void Update()
    {
        
    }
}
