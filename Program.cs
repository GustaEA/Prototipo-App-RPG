using System;
using System.Collections.Generic;
using System.Linq;
using RPG.Classes;

namespace RPG
{
	class Program
	{		
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();
			var ListaMobs = new List<Mobs>();

			while(opcaoUsuario != "X")
			{
				switch(opcaoUsuario)
				{
					case "1":
					ListaMobs = CriaListaMobs();							
						break;
					case "2":
						Batalha(ListaMobs);
						break;
					default:
						System.Console.WriteLine("Digite 1 ou 2");
						break;
				}
				
				opcaoUsuario = ObterOpcaoUsuario();
			}
		}

		

		//Cria Mobs com 1 atrubuto de defesa e ataque
		static Mobs CriarMob1()
		{
			System.Console.WriteLine("Digite o nome do Mob:");
			string nomeMob = Console.ReadLine();
			
			System.Console.WriteLine("Digite o nível do Mob:");
			int nivelMob = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite a vida do Mob:");
			int vidaMob = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o valor do atributo de ataque:");
			int atributoAtk1 = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o valor do atributo de defesa:");
			int atributoDfs1 = int.Parse(Console.ReadLine());
			
			Mobs novoMob = new Mobs(nomeMob, nivelMob, vidaMob, atributoAtk1, atributoDfs1);
			System.Console.WriteLine("Criou mob!");
			return novoMob;
		}
		
		//Cria Mobs com 2 atributos de ataque e defesa
		static Mobs CriarMob2()
		{
			System.Console.WriteLine("Digite o nome do Mob:");
			string nomeMob = Console.ReadLine();
			
			System.Console.WriteLine("Digite o nível do Mob:");
			int nivelMob = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite a vida do Mob:");
			int vidaMob = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o valor do primeiro atributo de ataque:");
			int atributoAtk1 = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o valor do segundo atributo de ataque:");
			int atributoAtk2 = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o valor do primeiro atributo de defesa:");
			int atributoDfs1 = int.Parse(Console.ReadLine());
			
			System.Console.WriteLine("Digite o valor do segundo atributo de defesa:");
			int atributoDfs2 = int.Parse(Console.ReadLine());
			
			Mobs novoMob = new Mobs(nomeMob, nivelMob, vidaMob, atributoAtk1, atributoAtk2, atributoDfs1, atributoDfs2);
			System.Console.WriteLine("Criou mob!");
			return novoMob;
		}	
		
		static List<Mobs> CriaListaMobs()
		{
			List<Mobs> ListaMobs = new List<Mobs>();
			System.Console.WriteLine("Quantos mobs deseja adicionar?");
			int numeroDesejadoDeMobs = int.Parse(Console.ReadLine());
			
			while (numeroDesejadoDeMobs > 0)
			{
				System.Console.WriteLine("Quantos Atributos de ataque e defesa ele usa?");
				int numeroAtributos = int.Parse(Console.ReadLine());
				
				switch(numeroAtributos)
				{
					case 1:
						Mobs mob1 = CriarMob1();
						ListaMobs.Add(mob1);
						numeroDesejadoDeMobs--;
						break;
					case 2:
						Mobs mob2 = CriarMob2();
						ListaMobs.Add(mob2);
						numeroDesejadoDeMobs--;
						break;
					default:
						System.Console.WriteLine("AAAAA");
						break;						
				}
			}
			return ListaMobs;			
		}
		private static void Batalha(List<Mobs> ListaMobs)
		{
			while (ListaMobs.Count > 0)
			{
				for (int i = 0; i < ListaMobs.Count; i++)
				{
					System.Console.WriteLine($"ID[{i}] Nome: {ListaMobs[i].Nome}, Vida atual: {ListaMobs[i].VidaAtual}");
				}
				System.Console.WriteLine("O que deseja fazer?");
				System.Console.WriteLine("1. Tirar vida dos mobs");
				System.Console.WriteLine("2. Adicionar vida aos mobs");
				int input = int.Parse(Console.ReadLine());
				
				switch(input)
				{
					case 1:
						TirarVida(ListaMobs);
						break;
					case 2:
						GanharVida(ListaMobs);
						break;
					default:
						System.Console.WriteLine("Digite 1 ou 2");
						break;
				}
			}
		}

		private static void GanharVida(List<Mobs> ListaMobs)
		{
			System.Console.WriteLine("Selecione o index do mob:");
			int indexMob = int.Parse(Console.ReadLine());

			if (ListaMobs.Contains(ListaMobs[indexMob]))
			{
				System.Console.WriteLine("Digite a vida a ser adicionada:");
				int vida = int.Parse(Console.ReadLine());

				ListaMobs[indexMob].VidaAtual = AdicionarVida(ListaMobs[indexMob].VidaAtual, vida);
				System.Console.WriteLine($"Nome: {ListaMobs[indexMob].Nome}, Vida atual: {ListaMobs[indexMob].VidaAtual}");
			}
		}

		private static void TirarVida(List<Mobs> ListaMobs)
		{
			System.Console.WriteLine("Selecione o index do mob:");
			int indexMob = int.Parse(Console.ReadLine());

			if (ListaMobs.Contains(ListaMobs[indexMob]))
			{
				System.Console.WriteLine("Digite o dano a ser tomado:");
				int dano = int.Parse(Console.ReadLine());

				ListaMobs[indexMob].VidaAtual = TomarDano(ListaMobs[indexMob].VidaAtual, dano);
				System.Console.WriteLine($"Nome: {ListaMobs[indexMob].Nome}, Vida atual: {ListaMobs[indexMob].VidaAtual}");
				if (ListaMobs[indexMob].VidaAtual <= 0)
				{
					System.Console.WriteLine($"{ListaMobs[indexMob].Nome} morreu!");
					ListaMobs.Remove(ListaMobs[indexMob]);					
				}
			}
		}

		private static string ObterOpcaoUsuario()
		{
			System.Console.WriteLine();			
			
			System.Console.WriteLine("1. Criar grupo de mobs para batalha!");
			System.Console.WriteLine("2. Batalhar!");			
			System.Console.WriteLine("X. Sair");
			
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
		
		static int TomarDano(int vida, int dano)
		{
			int vidaBatalha = vida - dano;			
			return vidaBatalha;
		}
		
		static int AdicionarVida(int vida, int vidaGanha)
		{
			int vidaNova = vida + vidaGanha;
			return vidaNova;
		}	
	}
}
