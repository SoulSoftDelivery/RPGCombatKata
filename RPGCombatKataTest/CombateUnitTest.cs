using RPGCombatKata;
using System.Security;
using Xunit;

namespace RPGCombatKataTest
{
    public class CombateUnitTest
    {
        //Cria um personagem para o teste
        Personagem personagem = new Personagem { Nome = "Goku" };

        //Verifica se o personagem morreu apos o dano
        [Fact]
        public void Danificar1000()
        {
            //Gera um dano de 1000
            personagem = Combate.Danificar(personagem, 1000);
            //Verifica a situação de vida do personagem
            Assert.Equal(personagem.Vivo, false);
        }

        //Verifica se o personagem continua vivo apos o dano
        [Fact]
        public void Danificar500()
        {
            //Gera um dano de 1000
            personagem = Combate.Danificar(personagem, 500);
            //Verifica a situação de vida do personagem
            Assert.Equal(personagem.Vivo, true);
        }

        //Verifica se o nivel de cura do personagem foi adicionado
        [Fact]
        public void Curar100()
        {
            personagem.Saude = 100;
            //Gera um dano de 1000
            personagem = Combate.Curar(personagem, 100);
            //Verifica a situação de saude do personagem
            Assert.Equal(personagem.Saude, 200);
        }

        //Verifica se o nivel de cura do personagem não excedeu o limite
        [Fact]
        public void Curar50()
        {
            //Gera um dano de 1000
            personagem = Combate.Curar(personagem, 1000);
            //Verifica a situação de saude do personagem
            Assert.Equal(personagem.Saude, 1000);
        }
    }
}
