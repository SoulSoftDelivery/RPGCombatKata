using System;

namespace RPGCombatKata
{
    public class Interacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Personagem FazInteracao { get; set; }
        public Personagem RecebeInteracao { get; set; }
        public int DistanciaPersonagens { get; set; }
    }

    public class Personagem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public double Saude { get; set; } = 1000;
        public int Nivel { get; set; } = 1;
        public TipoLutador TipoLutador { get; set; }
        public bool Vivo { get; set; } = true;
    }

    public class TipoLutador
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public int Alcance { get; set; }
    }

    public static class CombateUtils
    {
        public static bool ValidaDanificar(Interacao interacao)
        {
            if (
                interacao.RecebeInteracao.Vivo &&
                interacao.FazInteracao.Id != interacao.RecebeInteracao.Id &&
                interacao.DistanciaPersonagens <= interacao.FazInteracao.TipoLutador.Alcance
                )
            {
                return true;
            }

            return false;
        }

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
        public static Personagem Danificar(Interacao interacao, double qtdDanificar)
        {
            if (CombateUtils.ValidaDanificar(interacao))
            {
                qtdDanificar = CombateUtils.CalculaQtdRealDanificar(interacao.FazInteracao.Nivel, interacao.RecebeInteracao.Nivel, qtdDanificar);

                if ((interacao.FazInteracao.Saude - qtdDanificar) <= 0)
                {
                    interacao.RecebeInteracao.Saude = 0;
                    interacao.RecebeInteracao.Vivo = false;
                }
                else
                {
                    interacao.RecebeInteracao.Saude -= qtdDanificar;
                }
            }

            return interacao.RecebeInteracao;
        }

        public static Personagem Curar(Interacao interacao, int qtdCurar)
        {
            if (interacao.RecebeInteracao.Vivo && (interacao.FazInteracao.Id == interacao.RecebeInteracao.Id))
            {
                if ((interacao.RecebeInteracao.Saude + qtdCurar) >= 1000)
                {
                    interacao.RecebeInteracao.Saude = 1000;
                }
                else
                {
                    interacao.RecebeInteracao.Saude += qtdCurar;
                }
            }

            return interacao.RecebeInteracao;
        }
    }
}
