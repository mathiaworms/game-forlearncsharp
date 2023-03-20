using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class Game
    {
        HumanPlayer human_player;
      //  List<Player> listennemies = new List<Player>(); 
        List<Player> listennemies_sight = new List<Player>();
        int player_left;
        public Game(string _name)
        {

            human_player = new HumanPlayer(_name);
          /*  listennemies.Add(new Player("Josiane"));
            listennemies.Add(new Player("John"));
            listennemies.Add(new Player("Joe"));
            listennemies.Add(new Player("Joshua"));*/
            player_left = 10;
        }
        public void KillPlayer(Player _ennemy)
        {
            listennemies_sight.Remove(_ennemy);
            player_left--;
        }
        public bool IsStillOnGoing()
        {
            if (human_player.life_points > 0 && player_left > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowPlayers()
        {
            human_player.Showstate();
            Console.WriteLine("ils reste : " + listennemies_sight.Count + " ennemies");
            foreach(var ennemy in listennemies_sight)
            {
                Console.WriteLine("0 - " + ennemy.name + " a " + ennemy.life_points + " points de vie");
            }
        }
        public void Menu()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Quelle action veux-tu effectuer ?");
            Console.WriteLine("a - chercher une meilleure arme");
            Console.WriteLine("s - chercher à se soigner ");
            int i = 0;
            foreach (var ennemy in listennemies_sight)
            {
                Console.WriteLine(i + " - " + ennemy.name + " a " + ennemy.life_points + " points de vie");
                i++;
            }


        }
        public void MenuChoice()
        {
            string input = Console.ReadLine();
            var isNumeric = int.TryParse(input, out int number);
            if (!isNumeric)
            {
                switch (input)
                {
                    case "a":
                        human_player.SearchWeapons();
                        break;
                    case "s":
                        human_player.SearchHealthPack();
                        break;
                    default:
                        Console.WriteLine("echec");
                        break;
                }

            }
            else
            {
                if (!((listennemies_sight.Count - 1)  < number))
                {

                    human_player.Attacks(listennemies_sight[number]);

                    if (listennemies_sight[number].life_points <= 0)
                    {
                        KillPlayer(listennemies_sight[number]);
                    }
                }
                else
                {
                    Console.WriteLine("echec");
                }
            }

        }
        public void EnnemiesAttack()
        {
            foreach (var ennemy in listennemies_sight)
            {
                ennemy.Attacks(human_player);
            }
        }
        public void End()
        {
            if (human_player.life_points > 0)
            {
                Console.WriteLine("TU AS GAGNER ");
            }
            else
            {
                Console.WriteLine("Tu as perdu ..");
            }
        }
        public void NewPlayerInSight()
        {
            if (listennemies_sight.Count < player_left)
            {
                Random rnd = new Random();

                int did_appear = rnd.Next(1, 7);
                switch (did_appear)
                {
                    case 1:
                        Console.WriteLine("Aucun joueur n'apparait");
                        break;
                    case 2:
                    case 3:
                    case 4:
                        int random_name = rnd.Next(1, 4000);
                        string playergenerated = ("player_" + random_name);
                        listennemies_sight.Add(new Player(playergenerated));
                        Console.WriteLine("le joueur : " + playergenerated + "est apparu !");
                        break;
                    case 5:
                    case 6:
                        int random_name2 = rnd.Next(1, 4000);
                        string playergenerated2 = ("player_" + random_name2);
                        listennemies_sight.Add(new Player(playergenerated2));
                        Console.WriteLine("le joueur : " + playergenerated2 + "est apparu !");
                        int random_name3 = rnd.Next(1, 4000);
                        string playergenerated3 = ("player_" + random_name3);
                        listennemies_sight.Add(new Player(playergenerated3));
                        Console.WriteLine("le joueur : " + playergenerated3 + "est apparu !");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Tous les joueurs sont déjà en vue");
            }
        }
    }
}
