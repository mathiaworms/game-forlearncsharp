using app;

void App1()
{
    Player player1 = new Player("Josiane");
    Player player2 = new Player("José");
    Console.WriteLine("Voici l'état de chaque joueur :");
    player1.Showstate();
    player2.Showstate();
    Console.WriteLine("Passons à la phase d'attaque");
    while (player1.life_points > 0 && player2.life_points > 0)
    {
        Console.WriteLine("------------------------");
        player1.Attacks(player2);
        if (player2.life_points < 0)
        {
            break;
        }
        player2.Attacks(player1);
        player1.Showstate();
        player2.Showstate();
    }



}
void App2()
{
    Console.WriteLine("------------------------------------------------");
    Console.WriteLine("|Bienvenue sur 'ILS VEULENT TOUS MA POO' !      |");
    Console.WriteLine("|Le but du jeu est d'être le dernier survivant !|");
    Console.WriteLine("------------------------------------------------");

    Console.WriteLine("Quel est ton nom :");
    HumanPlayer user = new HumanPlayer(Console.ReadLine());
    List<Player> listennemies = new List<Player>();
    Player player1 = new Player("Josiane");
    Player player2 = new Player("José");
    listennemies.Add(player1);
    listennemies.Add(player2);
    while ((player1.life_points > 0 || player2.life_points > 0) && user.life_points > 0)
    {
        Console.WriteLine("------------------------");
        user.Showstate();
        player1.Showstate();
        player2.Showstate();
        Console.WriteLine("Quelle action veux-tu effectuer ?");
        Console.WriteLine("a - chercher une meilleure arme");
        Console.WriteLine("s - chercher à se soigner ");
        Console.WriteLine("0 - "+ player1.name + " a " + player1.life_points + " points de vie");
        Console.WriteLine("1 - "+ player2.name + " a " + player2.life_points + " points de vie");
        string input = Console.ReadLine();
        switch (input)
        {
            case "a": user.SearchWeapons();
                break;
            case "s": user.SearchHealthPack();
                break;
            case "0": user.Attacks(player1);
                break;
            case "1": user.Attacks(player2);
                break;
            default: Console.WriteLine("echec");
                break;
        }
        Console.WriteLine("-------l'ennemi riposte ------");
        foreach(var ennemy in listennemies)
        {
            if (ennemy.life_points > 0)
            {
                ennemy.Attacks(user);
            }
            
        }

        Console.WriteLine("-------etat du combat------");
       
    }
    if (user.life_points > 0)
    {
        Console.WriteLine("TU AS GAGNER ");
    }
    else
    {
        Console.WriteLine("Tu as perdu ..");
    }


}
void App3()
{
    Console.WriteLine("------------------------------------------------");
    Console.WriteLine("|Bienvenue sur 'ILS VEULENT TOUS MA POO' !      |");
    Console.WriteLine("|Le but du jeu est d'être le dernier survivant !|");
    Console.WriteLine("------------------------------------------------");

    Console.WriteLine("Quel est ton nom :");

    var gameinstance = new Game(Console.ReadLine());

    while (gameinstance.IsStillOnGoing())
    {
        gameinstance.NewPlayerInSight();
        gameinstance.ShowPlayers();
        gameinstance.Menu();
        gameinstance.MenuChoice();
        gameinstance.EnnemiesAttack();

    }
    gameinstance.End();



}
App3();