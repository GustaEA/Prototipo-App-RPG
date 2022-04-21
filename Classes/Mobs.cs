namespace RPG.Classes
{
	public class Mobs
	{
		public string Nome { get; set; }
		public int Nivel { get; set; }
		
		public int Vida { get; set; }
		public int VidaAtual { get; set; }
		public int AtributoAtk1 { get; set; }
		public int ModAtk1 { get; set; }		
		public int AtributoAtk2 { get; set; }
		public int ModAtk2 { get; set; }
		public int AtributoDfs1 { get; set; }
		public int ModDfs1 { get; set; }
		public int AtributoDfs2 { get; set; }
		public int ModDfs2 { get; set; }
		
		public Mobs(string nome, int nivel, int vida, int atributoatk1, int atributodfs1)
		{
			this.Nome = nome;
			this.Nivel = nivel;
			this.Vida = vida;
			this.VidaAtual = Vida;
			this.AtributoAtk1 = atributoatk1;
			this.ModAtk1 = CalculcaModificador(ModAtk1, atributoatk1);
			this.AtributoDfs1 = atributodfs1;	
			this.ModDfs1 = CalculcaModificador(ModDfs1, atributodfs1);					
		}
		
		public Mobs(string nome, int nivel, int vida, int atributoatk1, int atributoatk2, int atributodfs1, int atributodfs2)
		{
			this.Nome = nome;
			this.Nivel = nivel;
			this.Vida = vida;
			this.VidaAtual = Vida;
			this.AtributoAtk1 = atributoatk1;
			this.ModAtk1 = CalculcaModificador(ModAtk1, atributoatk1);
			this.AtributoAtk2 = atributoatk2;
			this.ModAtk2 = CalculcaModificador(ModAtk2, atributoatk2);
			this.AtributoDfs1 = atributodfs1;
			this.ModDfs1 = CalculcaModificador(ModDfs1, atributodfs1);
			this.AtributoDfs2 = atributodfs2;
			this.ModDfs2 = CalculcaModificador(ModDfs2, atributodfs2);
		}
		
		int CalculcaModificador(int modificador, int atributo)
		{
			modificador = -5;
			for (int i = 0; i <= atributo; i++)
			{				
				if(i % 2 == 0)
				{
					modificador++;
				}
			}
			return modificador;
		}
	}
}