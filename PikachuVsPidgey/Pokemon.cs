using System;


namespace PokemonVersionJavi
{
    class Pokemon
    {
        private string nombre;
        private int vida;
        private int daño;
        private int probAtacar;

        public Pokemon(string n, int v, int d, int p)
        {
            nombre = n;
            vida = v;
            daño = d;
            probAtacar = p;
        }

        //Metodos get

        public string GetNombre()
        {
            return nombre;
        }

        public int GetVida()
        {
            return vida;
        }

        public int GetDaño()
        {
            return daño;
        }

        public int GetProbAt()
        {
            return probAtacar;
        }
        //metodos Set
        public void SetVida(int v)
        {
            vida = v;
        }

        public void Dañar(int d)
        {
            vida -= d;
        }
    }
}
