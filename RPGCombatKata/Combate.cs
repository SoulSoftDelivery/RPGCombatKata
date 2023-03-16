using System;

namespace RPGCombatKata
{
    public class Personagem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public double Saude { get; set; } = 1000;
        public int Nivel { get; set; } = 1;
        public bool Vivo { get; set; } = true;
    }

    public static class CombateUtils
    {
        public static double CalculaQtdRealDanificar(int nivelPersonagemAtaca, int nivelPersonagemRecebeAtaque, double qtdDanificar)
        {
            if ((nivelPersonagemRecebeAtaque - nivelPersonagemAtaca) >= 5)
            {
                qtdDanificar = qtdDanificar / 2;
            }

            if ((nivelPersonagemAtaca - nivelPersonagemRecebeAtaque) >= 5)
            {
                qtdDanificar *= 1.5;
            }

            return qtdDanificar;
        }
    }

    public static class Combate
    {
        public static Personagem Danificar(Personagem personagemAtaca, Personagem personagemRecebeAtaque, double qtdDanificar)
        {
            if (personagemRecebeAtaque.Vivo && (personagemAtaca.Id != personagemRecebeAtaque.Id))
            {
                qtdDanificar = CombateUtils.CalculaQtdRealDanificar(personagemAtaca.Nivel, personagemRecebeAtaque.Nivel, qtdDanificar);

                if ((personagemRecebeAtaque.Saude - qtdDanificar) <= 0)
                {
                    personagemRecebeAtaque.Saude = 0;
                    personagemRecebeAtaque.Vivo = false;
                }
                else
                {
                    personagemRecebeAtaque.Saude -= qtdDanificar;
                }
            }

            return personagemRecebeAtaque;
        }

        public static Personagem Curar(Personagem personagemJogador, Personagem personagemCurar, int qtdCurar)
        {
            if (personagemJogador.Vivo && (personagemJogador.Id == personagemCurar.Id))
            {
                if ((personagemJogador.Saude + qtdCurar) >= 1000)
                {
                    personagemJogador.Saude = 1000;
                }
                else
                {
                    personagemJogador.Saude += qtdCurar;
                }
            }

            return personagemJogador;
        }
    }
}
