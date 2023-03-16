using RPGCombatKata;
using System.Security;
using Xunit;

namespace RPGCombatKataTest
{
    public class CombateUnitTest
    {
        Interacao interacao = new Interacao
        {
            FazInteracao = new Personagem {
                Nome = "Goku", 
                TipoLutador = new TipoLutador {
                    Alcance = 20, 
                    Nome = "Lutador longo alcance" 
                } 
            },
            RecebeInteracao = new Personagem
            {
                Nome = "Madimbu",
                TipoLutador = new TipoLutador
                {
                    Alcance = 2,
                    Nome = "Lutador corpo a corp"
                }
            },
            DistanciaPersonagens = 10
        };

        //Verifica se o personagem adversario morreu apos o dano de 1000
        [Fact]
        public void Danificar1000()
        {
            //Gera um dano de 1000
            var recebeInteracao = Combate.Danificar(interacao, 1000);
            //Verifica a situação de vida do personagem
            Assert.Equal(recebeInteracao.Vivo, false);
        }

        //Verifica se o adversario sofreu o dano de 500
        [Fact]
        public void Danificar500()
        {
            //Gera um dano de 500
            var recebeInteracao = Combate.Danificar(interacao, 500);
            //Verifica a situação de vida do personagem
            Assert.Equal(recebeInteracao.Saude, 500);
        }

        //Verifica se o jogador conseguiu causar dano a si mesmo
        [Fact]
        public void Danificar50()
        {
            //Seta que o jogador que recebe a interacao é o mesmo que faz
            interacao.RecebeInteracao = interacao.FazInteracao;
            //Gera um dano de 50
            var fazInteracao = Combate.Danificar(interacao, 50);
            //Verifica a situação de vida do personagem
            Assert.Equal(fazInteracao.Saude, 1000);
        }

        //Verifica se o nivel de cura do jogador foi adicionado
        [Fact]
        public void Curar100()
        {
            //Seta que o jogador que recebe a interacao é o mesmo que faz
            interacao.RecebeInteracao = interacao.FazInteracao;
            //Seta a saude do jogador em 100
            interacao.FazInteracao.Saude = 100;
            //Gera uma cura de 100
            var recebeInteracao = Combate.Curar(interacao, 100);
            //Verifica a situação de saude do personagem
            Assert.Equal(recebeInteracao.Saude, 200);
        }

        //Verifica se o nivel de cura do jogador não excedeu o limite
        [Fact]
        public void Curar50()
        {
            //Seta que o jogador que recebe a interacao é o mesmo que faz
            interacao.RecebeInteracao = interacao.FazInteracao;
            //Gera uma cura de 50
            var recebeInteracao = Combate.Curar(interacao, 50);
            //Verifica a situação de saude do personagem
            Assert.Equal(recebeInteracao.Saude, 1000);
        }

        //Verifica se o jogador curou o adversario
        [Fact]
        public void Curar40()
        {
            //Seta que a saude do adversario em 100
            interacao.RecebeInteracao.Saude = 100;
            //Gera uma cura de 40
            var recebeInteracao = Combate.Curar(interacao, 40);
            //Verifica a situação de saude do personagem
            Assert.Equal(recebeInteracao.Saude, 100);
        }

        //Verifica se o jogador causou dano em adversario fora de alcance
        [Fact]
        public void Danificar500ForaAlcance()
        {
            //Seta distancia entre os jogadores maior que o alcance
            interacao.DistanciaPersonagens = 30;
            //Gera um dano de 500
            var recebeInteracao = Combate.Danificar(interacao, 500);
            //Verifica a situação de saude do personagem
            Assert.Equal(recebeInteracao.Saude, 1000);
        }

        //Verifica se o jogador que recebe dano de oponente com diferenca de nivel maior que 5 tem o dano aumentado
        [Fact]
        public void Danificar500AumentarDanoPorNivel()
        {
            //Seta que o nivel do jogador que faz a interacao é 5 niveis maior do que o nivel do adversario
            interacao.FazInteracao.Nivel = 6;
            //Gera um dano de 500
            var recebeInteracao = Combate.Danificar(interacao, 500);
            //Verifica a situação de saude do personagem
            Assert.Equal(recebeInteracao.Saude, 250);
        }

        //Verifica se o jogador que recebe dano de oponente com diferenca de nivel menor que 5 tem o dano reduzido
        [Fact]
        public void Danificar500DiminuirDanoPorNivel()
        {
            //Seta que o nivel do jogador que recebe a interacao é 5 niveis maior do que o nivel do adversario
            interacao.RecebeInteracao.Nivel = 6;
            //Gera um dano de 500
            var recebeInteracao = Combate.Danificar(interacao, 500);
            //Verifica a situação de saude do personagem
            Assert.Equal(recebeInteracao.Saude, 750);
        }
    }
}
