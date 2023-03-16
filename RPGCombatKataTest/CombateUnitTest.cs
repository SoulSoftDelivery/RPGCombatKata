using RPGCombatKata;
using System.Security;
using Xunit;

namespace RPGCombatKataTest
{
    public class CombateUnitTest
    {
        //Cria o personagem do jogador atual
        Personagem jogador = new Personagem { Nome = "Goku" };

        //Cria o personagem adverário
        Personagem adversario = new Personagem { Nome = "Madimbu" };

        //Verifica se o personagem adversario morreu apos o dano de 1000
        [Fact]
        public void Danificar1000()
        {
            //Gera um dano de 1000
            jogador = Combate.Danificar(jogador, adversario, 1000);
            //Verifica a situação de vida do personagem
            Assert.Equal(adversario.Vivo, false);
        }

        //Verifica se o adversario sofreu o dano de 500
        [Fact]
        public void Danificar500()
        {
            //Gera um dano de 1000
            jogador = Combate.Danificar(jogador, adversario, 500);
            //Verifica a situação de vida do personagem
            Assert.Equal(adversario.Saude, 500);
        }

        //Verifica se o jogador conseguiu causar dano a si mesmo
        [Fact]
        public void Danificar50()
        {
            //Gera um dano de 1000
            jogador = Combate.Danificar(jogador, jogador, 50);
            //Verifica a situação de vida do personagem
            Assert.Equal(jogador.Saude, 1000);
        }

        //Verifica se o nivel de cura do jogador foi adicionado
        [Fact]
        public void Curar100()
        {
            jogador.Saude = 100;
            //Gera um dano de 1000
            jogador = Combate.Curar(jogador, jogador, 100);
            //Verifica a situação de saude do personagem
            Assert.Equal(jogador.Saude, 200);
        }

        //Verifica se o nivel de cura do jogador não excedeu o limite
        [Fact]
        public void Curar50()
        {
            //Gera um dano de 1000
            jogador = Combate.Curar(jogador, jogador, 50);
            //Verifica a situação de saude do personagem
            Assert.Equal(jogador.Saude, 1000);
        }

        //Verifica se o jogador curou o adversario
        [Fact]
        public void Curar40()
        {
            adversario.Saude = 100;
            //Gera um dano de 1000
            jogador = Combate.Curar(jogador, adversario, 40);
            //Verifica a situação de saude do personagem
            Assert.Equal(adversario.Saude, 100);
        }
    }
}
