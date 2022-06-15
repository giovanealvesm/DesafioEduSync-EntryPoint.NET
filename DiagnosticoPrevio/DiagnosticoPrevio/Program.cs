using System;
using System.Globalization;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Variaveis
            string nome, sexo, entradas;
            int idade = 0;
            bool validaIdade = false, validaAltura = false, validaPeso = false, validaSexo = false, validaNome = false, validaDados = false;
            double altura = 0, peso = 0, imc = 0;

            //Vetores
            string[] risco =
            {
                @"Muitas complicações de saúde como doenças pulmonares e cardiovasculares 
        podem estar associadas ao baixo peso.",
                @"Seu peso está ideal para suas referências.",
                @"Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.",
                @"Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.",
                @"O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas."
            };
            string[] recomendacoes =
            {
                @"Inclua carboidratos simples em sua dieta, além de proteínas
        - indispensáveis para ganho de massa magra.Procure um profissional.",
                @"Mantenha uma dieta saudável e faça seus exames periódicos.",
                @"Adote um tratamento baseado em dieta balanceada,
        exercício físico e medicação.A ajuda de um profissional pode ser interessante.",
                @"Adote uma dieta alimentar rigorosa, com o acompanhamento de um
        nutricionista e um médico especialista (endócrino).",
                @"Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar,
        um psicólogo e um médicoespecialista (endócrino)."
            };

            do
            {
                Cabeçalho(); //Função que mostra o titulo do programa.

                do // Solicita o nome para o usuario - E verifica se ele escreveu algo.
                {
                    Console.Write("Entre com seu nome: ");
                    nome = Console.ReadLine().Trim(); // Usando a função para retirar espaços vazios.

                    validaNome = string.IsNullOrWhiteSpace(nome); // Verifica se o usuario não digitou nada ou apenas espaços.
                    if (validaNome == true)
                    {
                        Console.Clear();
                        Cabeçalho();
                        Console.WriteLine("Nada digitado!\n");

                    }
                } while (validaNome == true);
                Console.WriteLine();

                do // Solicita a idade para o usuario - E verifica se a idade e maior que 0 e se é um inteiro.
                {
                    Console.Write("Entre com sua idade: ");
                    validaIdade = int.TryParse(Console.ReadLine(), out idade);

                    if (validaIdade == false || idade <= 0)
                    {
                        Console.Clear();
                        Cabeçalho();
                        Console.WriteLine("Idade invalida\n");
                    }

                } while (validaIdade == false || idade <= 0);
                Console.WriteLine();

                do // Solicita a altura do usuario.
                {
                    Console.Write("Entre com sua altura(Em METROS): ");
                    validaAltura = double.TryParse(Console.ReadLine()
                        .Replace(",", "."), // Metodo para trocar a virgula(,) pelo ponto final(.).
                        NumberStyles.Number,
                         CultureInfo.InvariantCulture, out altura);

                    if (altura <= 0)
                    {

                        Console.Clear();
                        Cabeçalho();
                        Console.WriteLine("Altura incorreta\n");

                    }
                } while (altura <= 0);
                Console.WriteLine();

                do // Solicita o peso para do usuario.
                {
                    Console.Write("Entre com seu peso(Em Kg): ");
                    validaPeso = double.TryParse(Console.ReadLine()
                        .Replace(",", "."),
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture, out peso);

                    if (peso <= 0)
                    {
                        Console.Clear();
                        Cabeçalho();
                        Console.WriteLine("Peso incorreto\n");
                    }
                } while (peso <= 0);
                Console.WriteLine();

                do // Verifia o sexo do usuario.
                {
                    Console.Write("Digite [F] para Feminio e [M] para Masculino: ");
                    sexo = Console.ReadLine().ToLower();
                    validaSexo = string.IsNullOrWhiteSpace(sexo);

                    if (sexo == "f" || sexo == "m")
                    {
                        validaSexo = false;
                    }
                    else
                    {
                        Console.Clear();
                        Cabeçalho();
                        Console.WriteLine("Sexo não defino!\n");
                    }
                } while (sexo is not "f" and not "m");

                if (sexo == "m")
                {
                    sexo = "Masculino";
                }
                else if (sexo == "f")
                {
                    sexo = "Feminino";
                }
                Console.Clear();
                Cabeçalho();
                Console.WriteLine($"Nome:   {nome}.");
                Console.WriteLine($"Idade:  {idade} anos.");
                Console.WriteLine($"Altura: {altura} m.");
                Console.WriteLine($"Peso:   {peso}Kg.");
                Console.WriteLine($"Sexo:   {sexo}.");
                Console.WriteLine();
                do
                {
                    Console.WriteLine("O dados digitados estão certos?"); // Apresenta para o usuario os dados sem sem nenhum tratamento, e verifica se está correto.
                    Console.Write("[S] Sim [N] Não: ");
                    entradas = Console.ReadLine();
                    validaDados = string.IsNullOrWhiteSpace(entradas); // verivica se não foi digitado nada.
                    if (validaDados == true)
                    {
                        Console.WriteLine("Nada digitado!");
                    }
                } while (entradas is not "s" and not "n");
                {
                    if (entradas == "s")
                    {
                        validaDados = true;
                    }
                    else if (entradas == "n")
                    {
                        validaDados = false;

                    }
                    else
                    {
                        Console.WriteLine("Entrada invalida");
                    }
                }
                Console.Clear();
            } while (entradas == "n");
            
            imc = Imc(altura, peso); // Guardando o resultado da função Imc() na variavel imc.
            
            Console.Write("Precione qualquer tecla para ver o resultado: ");
            Console.ReadKey();
            Console.Clear(); // Limpa o console.

            // Apresentando os dados finais para o usuario.
            Cabeçalho();
            Console.WriteLine($"\tNome:      {NoUpper(nome)}.");
            Console.WriteLine($"\tSexo:      {sexo}.");
            Console.WriteLine($"\tIdade:     {idade} anos");
            Console.WriteLine($"\tAltura:    {altura} m.");
            Console.WriteLine($"\tPeso:      {peso} Kg.");
            Console.WriteLine($"\tCategoria: {Categoria(idade)}.\n\n");

            Console.WriteLine("\tIMC desejável: entre 20 e 24.\n");
            
            Decora("=");
            Decora("=");
            Decora("=");

            if (imc < 20) // Verificação do IMC para condicional.
            {
                Console.WriteLine($"\n\n\tSua classificação IMC: Abaixo do peso ideal IMC inferior a 20.\n");
                Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                Console.WriteLine($"\tRiscos: {risco[0]}\n");
                Console.WriteLine($"\tRecomendação inicial: {recomendacoes[0]}\n");
            }
            else if (imc >= 20 && imc <= 24)
            {
                Console.WriteLine($"\n\n\tSua classificação IMC: Peso Normal IMC entre 20 e 24.\n");
                Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                Console.WriteLine($"\tRiscos: {risco[1]}\n");
                Console.WriteLine($"\tRecomendação inicial: {recomendacoes[1]}\n");
            }
            else if (imc >= 25 && imc <= 29)
            {
                Console.WriteLine($"\n\n\tSua classificação IMC: Execesso de peso IMC entre 25 e 29.\n");
                Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                Console.WriteLine($"\tRiscos: {risco[2]}\n");
                Console.WriteLine($"\tRecomendação inicial: {recomendacoes[2]}\n");
            }
            else if (imc >= 30 && imc <= 35)
            {
                Console.WriteLine($"\n\n\tSua classificação IMC: Obesidade IMC entre 30 e 35\n");
                Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                Console.WriteLine($"\tRiscos: {risco[3]}\n");
                Console.WriteLine($"\tRecomendação inicial: {recomendacoes[3]}\n");
            }
            else if (imc > 35)
            {
                Console.WriteLine($"\n\n\tSua classificação IMC: Super obesidade IMC superior a 35\n");
                Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                Console.WriteLine($"\tRiscos: {risco[4]}\n");
                Console.WriteLine($"\tRecomendação inicial: {recomendacoes[4]}\n");
            }
            Console.WriteLine();
            Decora("=");
            Decora("=");
            Decora("=\n\n");
        }
        // FUNÇÕES
        /// <summary>
        /// Usa o laço de repetição for para apresentar um string atribuida
        /// </summary>
        /// <param name="sinal"></param>
        public static void Decora(string sinal) // função com uma laço de repetição for para apresentar algum caracter para decorar
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write("=");
            }
        }
        public static void Cabeçalho() // titulo do programa
        {
            //Console.Write("\t");
            Decora("=");
            Console.Write("\t Diagnóstico Prévio \t");
            Decora("=");
            Console.WriteLine();
            Console.WriteLine();
        }
        /// <summary>
        /// Metodo para deixar apenas as primeiras letras de uma string em maiusculo.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>nomeUpper</returns>
        public static string NoUpper(string nome) // Função para deixar maiusculo as iniciais do nome
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
        }
        /// <summary>
        /// Classifica o usuario de a cordo com a idade
        /// </summary>
        /// <param name="idade"></param>
        /// <returns>categoria</returns>
        public static string Categoria(int idade) // Função que define a categoria do usuario
        {
            string categoria;

            string[] c =
            {
                "Infatil",
                "Juvenil",
                "Adulto",
                "Idoso"
            };
            if (idade < 12)
            {
                categoria = c[0];
            }
            else if (idade >= 12 && idade <= 20)
            {
                categoria = c[1];
            }
            else if (idade >= 21 && idade <= 65)
            {
                categoria = c[2];
            }
            else
            {
                categoria = c[3];
            }

            return categoria;
        }
        /// <summary>
        /// Calcula o IMC dado os parametros
        /// </summary>
        /// <param name="altura"></param>
        /// <param name="peso"></param>
        /// <returns>imc</returns>
        public static double Imc(double altura, double peso) // Calcula o IMC
        {
            double imc = 0;

            imc = peso / (Math.Pow(altura, 2));

            return imc;
        }
    }
}