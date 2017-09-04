using System;

namespace PikachuVsPidgey
{
    class Program
    {
        public static Random r = new Random();
        public static int turnoPikachu = 1;
        public static int turnoPidgey = 2;
        public static int turno = 1;

        public static int vidaPikachu=100;
        public static int vidaPidgey = 100;

        public static int dañoPikachu = 30;
        public static int dañoPidgey = 25;

        public static int probAtak = 80;

        public static double ProbCapturar()
        {
            return 99.697 - 0.697 * vidaPidgey;
        }

        public static void Inicio()
        {
            Console.WriteLine("COMBATE!!!!!!!");
            Console.ReadLine();
            Console.WriteLine("Pidgey salvaje aparecio");
            Console.ReadLine();
            Console.WriteLine("Pikachu te elijo a ti!!!");
            Console.ReadLine();
        }

        public static void Menu()
        {
            Console.WriteLine("Elige tu opcion");
            Console.WriteLine("1: Atacar");
            Console.WriteLine("2: Lanzar pokeball");
            Console.WriteLine("3: Huir");
        }

        public static int PedirOpcion()
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

        public static void EscribirVida()
        {
            Console.WriteLine("PIKACHU: {0}", vidaPikachu);
            Console.WriteLine("PIDGEY: {0}", vidaPidgey);
        }

        public static void TurnoPika(int opcion)
        {
            int aleatorio = r.Next(0, 100);
            if(opcion==1)
            {
                Console.WriteLine("Pikachu uso impactrueno");
                Console.ReadLine();
                if (aleatorio < probAtak)
                {
                    
                    Console.WriteLine("Pidgey perdio {0} puntos de vida", dañoPikachu);
                    vidaPidgey -= dañoPikachu;
                    if (vidaPidgey <= 0)
                    {
                        Console.WriteLine("Pidgey se debilito");
                        vidaPidgey = 0;
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
        public static void TurnoPidgey()
        {
            int aleatorio = r.Next(0,100);
            Console.WriteLine("Pidgey uso Tornado");
            Console.ReadLine();
            if (aleatorio<probAtak)
            {
                
                Console.WriteLine("Pikachu perdio {0} puntos de vida", dañoPidgey);
                vidaPikachu -= dañoPidgey;
                if(vidaPikachu<=0)
                {
                    Console.WriteLine("Pikachu se debilito");
                    vidaPikachu = 0;
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

        public static void Main(string[] args)
        {
            int opcion = 0;
            Inicio();
            while(turno !=3)
            {
                EscribirVida();
                if (turno==1)
                {
                    Menu();
                    opcion = PedirOpcion();
                }
                if(opcion ==3)
                {
                    turno = 3;
                }
                switch(turno)
                {
                    case 1: TurnoPika(opcion);  break;
                    case 2: TurnoPidgey();  break;
                }
                Console.ReadLine();
            }
        }
    }
}
