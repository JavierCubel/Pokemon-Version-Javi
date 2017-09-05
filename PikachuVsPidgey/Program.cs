using System;

namespace PokemonVersionJavi
{
    class Program
    {
        private Random r = new Random();
        private int p = 80;

        private Pokemon pikachu;
        private Pokemon pidgey;

        private int turnoPikachu = 1;
        private int turnoPidgey = 2;
        private int turno = 1;

        

        public Program()
        {
            pikachu = new Pokemon("pikachu", 100, 30, p);
            pidgey = new Pokemon("pidgey", 100, 25, p);
        }

        

        public double ProbCapturar()
        {
            return 99.697 - 0.697 * pidgey.GetVida();
        }

        public void Inicio()
        {
            Console.WriteLine("COMBATE!!!!!!!");
            Console.ReadLine();
            Console.WriteLine("Pidgey salvaje aparecio");
            Console.ReadLine();
            Console.WriteLine("Pikachu te elijo a ti!!!");
            Console.ReadLine();
        }

        public void Menu()
        {
            Console.WriteLine("Elige tu opcion");
            Console.WriteLine("1: Atacar");
            Console.WriteLine("2: Lanzar pokeball");
            Console.WriteLine("3: Huir");
        }

        public int PedirOpcion()
        {
            int opcion = 0;
            bool check = false;
            while(!check)
            {
                Int32.TryParse(Console.ReadLine(), out opcion);
                check = ((opcion>0)&&(opcion<4));
                if(!check)
                {
                    Console.WriteLine("Debes introducir un numero entre 1 y 3");
                }
            }
            return opcion;
        }

        public void EscribirVida()
        {
            Console.WriteLine("PIKACHU: {0}", pikachu.GetVida());
            Console.WriteLine("PIDGEY: {0}", pidgey.GetVida());
        }

        public void TurnoPika(int opcion)
        {
            int aleatorio = r.Next(0, 100);
            if(opcion==1)
            {
                Console.WriteLine("Pikachu uso impactrueno");
                Console.ReadLine();
                if (aleatorio < pikachu.GetProbAt())
                {
                    
                    Console.WriteLine("Pidgey perdio {0} puntos de vida", pikachu.GetDaño());
                    pidgey.Dañar(pikachu.GetDaño()); 
                    if (pidgey.GetVida() <= 0)
                    {
                        Console.WriteLine("Pidgey se debilito");
                        pidgey.SetVida(0);
                        turno = 3;
                    }
                    else
                    {
                        turno = 2;
                    }
                }
                else
                {
                    Console.WriteLine("El ataque de Pikachu fallo");
                    turno = 2;
                }
            }
            else if(opcion ==2)
            {
                Console.WriteLine("Lanzaste una pokeball");
                Console.ReadLine();
                if (aleatorio < ProbCapturar())
                {
                    Console.WriteLine("Pidgey capturado!!!");
                    turno = 3;
                }
                else
                {
                    Console.WriteLine("Pidgey se escapo!!!");
                    turno = 2;
                }
            }
        }
        public void TurnoPidgey()
        {
            int aleatorio = r.Next(0,100);
            Console.WriteLine("Pidgey uso Tornado");
            Console.ReadLine();
            if (aleatorio<pidgey.GetProbAt())
            {
                
                Console.WriteLine("Pikachu perdio {0} puntos de vida", pidgey.GetDaño());
                pikachu.Dañar(pidgey.GetDaño());
                if(pikachu.GetVida() <= 0)
                {
                    Console.WriteLine("Pikachu se debilito");
                    pikachu.SetVida(0);
                    turno = 3;
                }
                else
                {
                    turno = 1;
                }
            }
            else
            {
                Console.WriteLine("El ataque de Pidgey fallo");
                turno = 1;
            }
        }

        public void Combate()
        {
            int opcion = 0;
            Inicio();
            while (turno != 3)
            {
                EscribirVida();
                if (turno == 1)
                {
                    Menu();
                    opcion = PedirOpcion();
                }
                if (opcion == 3)
                {
                    turno = 3;
                }
                switch (turno)
                {
                    case 1: TurnoPika(opcion); break;
                    case 2: TurnoPidgey(); break;
                }
                Console.ReadLine();
            }
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Combate();
        }
    }
}
