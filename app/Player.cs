using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace app
{
    public class Player
    {
        public string name { get; set; }
        public int life_points { get; set; }

        public Player(string _name)
        {
            this.name = _name;
            this.life_points = 10;
        }
        public void Showstate()
        {
            Console.WriteLine(name + " à " + life_points + " points de vie");
        }
        public void GetsDamage(int _damage)
        {
            Console.WriteLine("Il lui inflige " + _damage + " points de damage");
            life_points -= _damage;
            if (life_points <= 0)
            {
                Console.WriteLine("Le joueur " + name + " à été tué ! ");
            }
        }
        public void Attacks(Player _player)
        {
            Console.WriteLine("le joueur " + name + " attaque le joueur " + _player.name);
            int _damage = ComputeDamage();
            _player.GetsDamage(_damage);

        }

        public static int ComputeDamage()
        {
            Random rnd = new Random();

            return rnd.Next(1, 7);
        }
    }
    public class HumanPlayer : Player
    {
        int weapon_level = 0;
        public HumanPlayer(string _name) : base(_name)
        {
            this.name = _name;
            this.life_points = 100;
            this.weapon_level = 1;
        }
        public void Showstate()
        {
            Console.WriteLine(name + " à " + life_points + " points de vie et une arme niveau = " + weapon_level);
        }
        public void Attacks(Player _player)
        {
            Console.WriteLine("le joueur " + name + " attaque le joueur " + _player.name);
            int _damage = ComputeDamage(this.weapon_level);
            _player.GetsDamage(_damage);

        }

        public static int ComputeDamage(int _weapon_level)
        {
            Random rnd = new Random();

            return rnd.Next(1, 7) * _weapon_level;
        }
        public void SearchWeapons()
        {
            Random rnd = new Random();

            int weapon_found = rnd.Next(1, 7);
            Console.WriteLine("Tu as Trouvée une arme de niveau : " + weapon_found);
            if (weapon_found > this.weapon_level)
            {
                this.weapon_level = weapon_found;
                Console.WriteLine("Youhou! elle est meilleure que ton arme actuelle , tu la prend  ");
            }
            else
            {
                Console.WriteLine("elle est nule , dommage ");
            }
        }
        public void SearchHealthPack()
        {
            Random rnd = new Random();

            int result_of_search = rnd.Next(1, 7);
            switch (result_of_search)
            {
                case 1: 
                    Console.WriteLine("tu as rien trouvée ");
                    break;
                case 2: case 3: case 4: case 5: 
                    Console.WriteLine("Bravo , tu as trouvée un pack de +50 pdv!");
                    this.life_points += 50;
                    if (this.life_points > 100)
                    {
                        this.life_points= 100;
                    }
                    break;
                case 6:
                    Console.WriteLine("Waow, tu as trouvé un pack de +80 points de vie !");
                    this.life_points += 80;
                    if (this.life_points > 100)
                    {
                        this.life_points = 100;
                    }
                    break;
            }
        }
    }
}
