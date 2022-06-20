using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Variaveis
            string nome, sexo, entradas, reiniciar;

            int idade = 0;
            bool validaIdade = false, validaAltura = false, validaPeso = false,
                validaSexo = false, validaNome = false, validaDados = false, validaEntrada = false;
            double altura, peso = 0, imc = 0;

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

            // Laço de repetição que ao final do programa questiona se o usuario gostaria de reiniciar o programa.
            do
            {
                // Laço de repetição para comfirmação de dados.
                do
                {
                    Console.WriteLine();
                    Cabecalho(); //Função que mostra o titulo do programa.

                    do // Solicita o nome para o usuario - E verifica se ele escreveu algo.
                    {
                        Console.Write("Digite seu nome: ");
                        nome = Console.ReadLine().Trim(); // Usando a função Trim para retirar espaços vazios.

                        // Verifica se o usuario não digitou nada ou apenas espaços usando a função IsNullOrWhiteSpace().
                        // Limpa o console e apresenta novamente o pedido de entrada de dados para o usuario.
                        validaNome = string.IsNullOrWhiteSpace(nome); // Verifica se foi digitado algo caso comtrario entra na primeira condicional;
                        if (validaNome == true)
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("Você não digitou nada!\n");
                        }
                        else if (nome.All(char.IsDigit)) // Verifica se foi digitado apenas números, usando a Linq.
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("Você digitou apenas números!\n");
                            validaNome = true;
                        }
                    } while (validaNome == true);

                    Console.WriteLine(); // Pula uma linha.

                    // Solicita a idade para o usuario.
                    // E verifica se a idade é maior que 0 e se é um inteiro e limita a idade max de 150 anos(Baseado no livrodos recordes).
                    // Caso não atendido os requisitos limpa console e reinicia etapa.
                    do
                    {
                        Console.WriteLine("Min 1 ano,  Max 120 anos");
                        Console.Write("Entre com sua idade: ");

                        validaIdade = int.TryParse(Console.ReadLine(), out idade); // Verifica se não foi digitado nada.

                        if (validaIdade == false) // condição se não for nada digitado
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("Entrada incorreta!\n");
                        }
                        else if (idade < 1) // condição se a idade for menor ou igual a 0.
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("Entrada somente acima 1(um) ano!\n");
                        }
                        else if (idade >= 120)// Condição se idade for maior ou igual a 120
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("Você não tem mais de 120 anos!\n");
                        }

                    } while (validaIdade == false || idade < 1 || idade >= 120);
                    Console.WriteLine();

                    // Solicita a altura do usuario e limita a 2.6 metros(Baseado no livros dos recordes).
                    // usando como validação Replace para trocar virgula por ponto, NumberStyle para receber numeros e CultureInfo.
                    // Caso não atendido os requisitos limpa o console e reinicia a etapa.
                    do
                    {
                        Console.WriteLine("Min 1m, Max 2,6m.");
                        Console.Write("Entre com sua altura em metros(EX: 1,5): ");
                        validaAltura = double.TryParse(Console.ReadLine()
                                                .Replace(",", "."),
                                                NumberStyles.Number,
                                                CultureInfo.InvariantCulture, out altura);

                        if (altura < 1) // Condição para altura menor ou igual a 0.
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.Write("Altura não aceita valores negativos ou outro tipo de entrada.\n\nApenas ");
                        }
                        else if (altura >= 2.6) // Condição para altura maior que 2.6m.
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("A maior pessoa do mundo tem menos de 2.6m, tenta de novo!\n");
                        }
                    } while (altura < 1 || altura > 2.6);
                    Console.WriteLine();

                    // Solicita o peso para do usuario com limite de 600 Kg(Baseado no livro dos recordes).
                    // Usando o mesmo metodo de altura para validadção.
                    do
                    {
                        Console.WriteLine("Min 1kg, Max 250kg.");
                        Console.Write("Entre com seu peso em Kg(EX: 54,6): ");
                        validaPeso = double.TryParse(Console.ReadLine()
                                                .Replace(",", "."),
                                                NumberStyles.Number,
                                                CultureInfo.InvariantCulture, out peso);

                        if (peso < 1) // Condição para peso menor que 1Kg
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.Write("Peso não aceita valores diferentes de peso ");
                        }
                        else if (peso >= 250) // Condição para peso superior a 250Kg.
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine($"Você digitou {peso}, o maximo é 250kg!");
                        }
                        else if (validaPeso == false) // Condição para entradas diferente de numeros reais.
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("Você digitou algo errado ou não digitou nada!");
                        }
                    } while (peso < 1 || peso >= 250);
                    Console.WriteLine();

                    // Verifia o sexo do usuario.
                    // Caso não atendido os requisitos limpa o console e reinicia a etapa.
                    do

                    {
                        Console.Write("Digite [F] para Feminino e [M] para Masculino: ");
                        sexo = Console.ReadLine().ToLower();
                        validaSexo = string.IsNullOrWhiteSpace(sexo);
                        if (validaSexo == true) // Condição se não foi digitado nada.
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.WriteLine("Você não digitou nada!\n");
                        }
                        else if (sexo == "f") // Se entrada f atualiza o valor da variavel sexo para Feminino.
                        {
                            sexo = "Feminino";
                        }
                        else if (sexo == "m") // se entrada m atualiza o valor da variavel sexo para Masculino.
                        {
                            sexo = "Masculino";
                        }
                        else if (sexo != "f" && sexo != "m") // Condição para entradas validadas pelo valida idade mas diferente de m e f
                        {
                            Console.Clear();
                            Cabecalho();
                            Console.Write("Entrada invalida!\n\nApenas ");
                        }

                    } while (validaSexo == true || sexo != "Feminino" && sexo != "Masculino");

                    // Valida a entrada do usuario e atribui valor a variavel sexo.

                    // Apresentação de dados para verificar.
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine($"Nome:   {nome}.");
                    Console.WriteLine($"Idade:  {idade} anos.");
                    Console.WriteLine($"Altura: {altura} m.");
                    Console.WriteLine($"Peso:   {peso} Kg.");
                    Console.WriteLine($"Sexo:   {sexo}.");
                    Console.WriteLine();

                    // Verifica se os dados apresentados estão corretos, caso o usuario opte por sim o console sera limpo e reiniciar o programa.
                    // Caso o usuario opte por não o console será limpo e o programa continuara.
                    do
                    {
                        Console.WriteLine("O dados digitados estão certos?");
                        Console.Write("[S] Sim [N] Não: ");
                        entradas = Console.ReadLine().ToLower();
                        validaDados = string.IsNullOrWhiteSpace(entradas); // Verifica se não foi digitado nada ou apenas espaços em brancos, se foi digitado algo são na variavel entradas para validação..
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

                // Guardando o resultado da função Imc() na variavel imc.
                imc = Imc(altura, peso);

                // Apresentando os dados finais para o usuario, após confirmação dos dados estarem corretos.
                Cabecalho();
                Console.WriteLine($"\tNome:      {NoUpper(nome)}."); // Nome apresentado com as primeiras letras maiusculas.
                Console.WriteLine($"\tSexo:      {sexo}.");
                Console.WriteLine($"\tIdade:     {idade} anos.");
                Console.WriteLine($"\tAltura:    {altura} m.");
                Console.WriteLine($"\tPeso:      {peso} Kg.");
                Console.WriteLine($"\tCategoria: {Categoria(idade)}.\n\n"); // Categoria apresentada de acordo com a idade do usuario passando como atributo em uma verificação na função Categoria.

                // Mensagem estatica indeprendente dos valores colocados pelo usuario;
                Console.WriteLine("\tIMC desejável: entre 20 e 24.\n");

                // Função decora sendo usada para separa os dados do resultado.
                Decora("=");
                Decora("=");
                Decora("=");

                // Verifica o retorno da função IMC para ser mostrado o resultado final ao usuario.
                if (imc < 20) // Se a condição for verdadeira vai ser exibido a classificação imc o resultado e as posições 0 dos vetores de Riscos e Recomendacoes.
                {
                    Console.WriteLine($"\n\n\tSua classificação IMC: Abaixo do peso ideal IMC inferior a 20.\n");
                    Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                    Console.WriteLine($"\tRiscos: {risco[0]}\n");
                    Console.WriteLine($"\tRecomendação inicial: {recomendacoes[0]}\n");
                }
                else if (imc >= 20 && imc < 25) // Se a condição for verdadeira vai ser exibido a classificação o resultado e a posição 1 dos vetores Riscos e Recomendacoes.
                {
                    Console.WriteLine($"\n\n\tSua classificação IMC: Peso Normal IMC entre 20 e 24.\n");
                    Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                    Console.WriteLine($"\tRiscos: {risco[1]}\n");
                    Console.WriteLine($"\tRecomendação inicial: {recomendacoes[1]}\n");
                }
                else if (imc >= 25 && imc < 30)// Se a condição for verdadeira vai ser exibido a classificação o resultado e a posição 2 dos vetores Riscos e Recomendacoes.
                {
                    Console.WriteLine($"\n\n\tSua classificação IMC: Execesso de peso IMC entre 25 e 29.\n");
                    Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                    Console.WriteLine($"\tRiscos: {risco[2]}\n");
                    Console.WriteLine($"\tRecomendação inicial: {recomendacoes[2]}\n");
                }
                else if (imc >= 30 && imc <= 35)// Se a condição for verdadeira vai ser exibido a classificação o resultado e a posição 3 dos vetores Riscos e Recomendacoes.
                {
                    Console.WriteLine($"\n\n\tSua classificação IMC: Obesidade IMC entre 30 e 35\n");
                    Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                    Console.WriteLine($"\tRiscos: {risco[3]}\n");
                    Console.WriteLine($"\tRecomendação inicial: {recomendacoes[3]}\n");
                }
                else if (imc > 35)// Se a condição for verdadeira vai ser exibido a classificação o resultado e a posição 4 dos vetores Riscos e Recomendacoes.
                {
                    Console.WriteLine($"\n\n\tSua classificação IMC: Super obesidade IMC superior a 35\n");
                    Console.WriteLine($"\tResultado IMC: {imc:n2}\n");
                    Console.WriteLine($"\tRiscos: {risco[4]}\n");
                    Console.WriteLine($"\tRecomendação inicial: {recomendacoes[4]}\n");
                }

                Console.WriteLine();
                Decora("=");
                Decora("=");
                Decora("=");
                Console.WriteLine();
                Console.WriteLine();

                do
                {
                    // Apresentando a escola para o usuario retornar no inicio do programa ou finalizar.
                    // Se sim o console sera limpo e o programa retorno no inicio.
                    Console.Write("Deseja refazer o teste: [s] sim [n] não. ");
                    reiniciar = Console.ReadLine().ToLower();
                    validaEntrada = string.IsNullOrWhiteSpace(reiniciar); // Função de verificação de dados nulos e espaço vazios.
                    if (reiniciar != "s" && reiniciar != "n")
                    {
                        Console.WriteLine("Entrada incorreta!");
                    }
                    if (validaEntrada == true)
                    {
                        Console.WriteLine("Você não digitou nada!");
                    }
                } while (reiniciar != "s" && reiniciar != "n");

                if (reiniciar == "s")
                {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine("Vamos reiniciar!");
                    Thread.Sleep(1000); // Função para imitar tempo de carregamento.
                    Console.Clear();
                }
                if (reiniciar == "n")
                {
                    Console.Clear();
                    Cabecalho();
                    Console.WriteLine("Obrigado por fazer seu teste de IMC!\n");
                    Decora("=");
                    Decora("=");
                    Decora("=");
                }
                if (reiniciar != "n" || reiniciar != "s")
                {
                    Console.WriteLine("Entrada incorreta!");
                }
            } while (reiniciar == "s");
        }
        // FUNÇÕES
        /// <summary>
        /// Função com uma laço de repetição for para apresentar um caracter para decorar pré determinado.
        /// </summary>
        /// <param name="sinal"></param>
        public static void Decora(string sinal)
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write("=");
            }
        }
        // titulo do programa.
        public static void Cabecalho()
        {
            //Console.Write("\t");
            Decora("=");
            Console.Write("\t Diagnóstico Prévio \t");
            Decora("=");
            Console.WriteLine();
            Console.WriteLine();
        }
        /// <summary>
        /// Função para deixar maiusculo as iniciais do nome, pasando como parametro a variavel nome.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>nomeUpper</returns>
        public static string NoUpper(string nome)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
        }
        /// <summary>
        /// Função que define a categoria do usuario usando um vetor para guardar as categoria e usando estrutura condicional composta para verificar idade.
        /// </summary>
        /// <param name="idade"></param>
        /// <returns>categoria</returns>
        public static string Categoria(int idade)
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
        /// Calcula o IMC, usando a função matematica Math.Pow e atribuindo o resultado na variavel imc.
        /// </summary>
        /// <param name="altura"></param>
        /// <param name="peso"></param>
        /// <returns>imc</returns>
        public static double Imc(double altura, double peso)
        {
            double imc = 0;

            imc = peso / (Math.Pow(altura, 2));

            return imc;
        }
    }
}