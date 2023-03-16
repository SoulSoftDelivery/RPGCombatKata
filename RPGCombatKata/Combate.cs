using System;

namespace RPGCombatKata
{
    public class Personagem
    {
        public string Nome { get; set; }
        public int Saude { get; set; } = 1000;
        public int Nivel { get; set; } = 1;
        public bool Vivo { get; set; } = true;
    }

    public static class Combate
    {
        public static Personagem Danificar(Personagem personagem, int totalDanificar)
        {
            if (personagem.Vivo)
            {
                if ((personagem.Saude - totalDanificar) <= 0)
                {
                    personagem.Saude = 0;
                    personagem.Vivo = false;
                }
                else
                {
                    personagem.Saude -= totalDanificar;
                }
            }

            return personagem;
        }

        public static Personagem Curar(Personagem personagem, int totalCurar)
        {
            if (personagem.Vivo)
            {
                if ((personagem.Saude + totalCurar) >= 1000)
                {
                    personagem.Saude = 1000;
                }
                else
                {
                    personagem.Saude += totalCurar;
                }
            }

            return personagem;
        }
    }
}
