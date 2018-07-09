using System;

namespace ZuulCS
{
    public class Game
    {
        private Parser parser;
        private Player player;

        public Game()
        {
            parser = new Parser();
            player = new Player();
            createRooms();
        }

        private void createRooms()
        {
            Room outside, pokegym, pokecentre, lab, office, attic, tree, gate, alley, sewer, sewerEnd, escape ,secretRoom;

            // create the rooms
            outside = new Room("outside the main entrance of an old abandond PokeGym");
            pokegym = new Room("in a pokemon theatre");
            pokecentre = new Room("in the broken down pokecenter");
            lab = new Room("in a pokemon testing facility");
            office = new Room("in the computing admin office, " + "there is a computer stil on... " + "it says that test subject 42 has failed, in 1982");
            attic = new Room("in the dusty room upstairs, " + "ratata's have made it their home");
            tree = new Room("in a broken tree house, " + "there are some pidgeys in here");
            alley = new Room("in a back alley behind the pokegym, " + "there are some stinky containers. " + "There is a coffin");
            sewer = new Room("down in the nasty, stinkey sewer, " + "you don't want to be here for long. " + "There is a long tunnel to the right");
            sewerEnd = new Room("at a dead end of the sewer! " + "there is no way else to go exept for back or up");
            gate = new Room("outside the pokemon testing complexes gate, " + "go north to escape and win the game!");
            escape = new Room("past the gate, " + "congratulations you escaped! " + "Type 'exit' to exit the game") ;
            secretRoom = new Room("are in a secret room!, there is a Masterball in here. They are rumored to be able to catch a legendary pokemon on their first throw.");

            // initialise room exits
            outside.setExit("east", pokegym);
            outside.setExit("south", lab);
            outside.setExit("west", pokecentre);
            outside.setExit("up", tree);

            tree.setExit("down", outside);

            gate.setExit("north", escape);
            gate.setExit("south", sewerEnd);

            pokegym.setExit("up", attic);
            pokegym.setExit("west", outside);
            pokegym.setExit("north", alley);

            attic.setExit("down", pokegym);

            alley.setExit("south", pokegym);
            alley.setExit("down", sewer);

            sewer.setExit("up", alley);
            sewer.setExit("east", sewerEnd);

            sewerEnd.setExit("up", gate);
            sewerEnd.setExit("south", sewer);

            pokecentre.setExit("east", outside);

            lab.setExit("north", outside);
            lab.setExit("east", office);
            lab.setExit("", secretRoom);

            secretRoom.setExit("up", lab);

            office.setExit("west", lab);

            //create items

            tree.RoomInventory.GrabItem(new Item());

            player.CurrentRoom = pokecentre;  // start game outside
            
        }

        /**
	     *  Main play routine.  Loops until end of play.
	     */
        public void play()
        {
            printWelcome();

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.
            bool finished = false;
            while (!finished)
            {
                Command command = parser.getCommand();
                finished = processCommand(command);
            }
            Console.WriteLine("Thank you for playing.");
        }

        /**
	     * Print out the opening message for the player.
	     */
        private void printWelcome()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to HorrorMon!");
            Console.WriteLine("HorrorMon is a new, amazing maze/horror game.");
            Console.WriteLine("Type 'help' if you need help.");
            Console.WriteLine();
            Console.WriteLine(player.CurrentRoom.getLongDescription());
        }

        /**
	     * Given a command, process (that is: execute) the command.
	     * If this command ends the game, true is returned, otherwise false is
	     * returned.
	     */
        private bool processCommand(Command command)
        {
            bool wantToQuit = false;

            if (command.isUnknown())
            {
                Console.WriteLine("Try something else, " + "type 'help' for help");
                Console.WriteLine("----------------------------------------------------");
                return false;
            }

            string commandWord = command.getCommandWord();
            switch (commandWord)
            {
                case "help":
                    printHelp();
                    break;
                case "go":
                    goRoom(command);
                    break;
                case "quit":
                    wantToQuit = true;
                    break;
                case "look":
                    looked();
                    break;
                case "inventory":
                    CheckInventory();
                    break;
                case "health":
                    CheckHealth();
                    break;
                case "grab":
                    
                    break;
                case "use":
                    UseItem();
                    break;
                case "exit":
                    ExitGame();
                    break;
            }

            return wantToQuit;
        }

        // implementations of user commands:

        /**
	     * Print out some help information.
	     * Here we print some stupid, cryptic message and a list of the
	     * command words.
	     */
        private void printHelp()
        {
            Console.WriteLine("You are lost. You have no pokeballs with you.");
            Console.WriteLine("You wander around at the pokegym.");
            Console.WriteLine();
            Console.WriteLine("Your command words are:");
            parser.showCommands();
            Console.WriteLine("----------------------------------------------------");

        }

        /**
	     * Try to go to one direction. If there is an exit, enter the new
	     * room, otherwise print an error message.
	     */
        private void goRoom(Command command)
        {
            if (!command.hasSecondWord())
            {
                // if there is no second word, we don't know where to go...
                Console.WriteLine("Go where?");
                Console.WriteLine("----------------------------------------------------");
                return;
            }

            string direction = command.getSecondWord();

            // Try to leave current room.
            Room nextRoom = player.CurrentRoom.getExit(direction);

            if (nextRoom == null)
            {
                Console.WriteLine("There is no door  " + direction + "!");
                Console.WriteLine("----------------------------------------------------");
            }
            else
            {
                player.IsAlive();
                player.Damage(10);
                player.CurrentRoom = nextRoom;
                Console.WriteLine(player.CurrentRoom.getLongDescription());
                Console.WriteLine("----------------------------------------------------");

            }

        }
        private void looked()
        {
            Console.WriteLine(player.CurrentRoom.getLongDescription());
            
            Console.WriteLine(player.CurrentRoom.RoomInventory.Contents.Count + " Item(s) in the room!");
            for (int i = 0; i < player.CurrentRoom.RoomInventory.Contents.Count; i++)
            {

            }
            
        }

        public void CheckInventory()
        {
            //Console.WriteLine(player.GrabItem);

        }

        public void CheckHealth()
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("----------------------------------------------------");

        }

        public void UseItem()
        {

        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }

    }
}
