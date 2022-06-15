﻿using System;
using System.Globalization;
using System.Runtime.ConstrainedExecution;

using static System.Net.Mime.MediaTypeNames;

namespace DiagnosticoPrevio
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Variaveis
            string nome, sexo;
            int idade = 0;
            bool validaIdade = false, validaAltura = false, validaPeso = false;
            double altura = 0, peso = 0, imc = 0;
            //Vetores
            string[] risco =
            {
                "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.",
                "Seu peso está ideal para suas referências. ",
                "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.",
                "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.",
                "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas."
            };
            string[] recomendacoes =
            {
                "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra. Procure um profissional .",
                "Mantenha uma dieta saudável e faça seus exames periódicos.",
                "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante.",
                "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista (endócrino).",
                "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médicoespecialista (endócrino)."
            };

            //Função que mostra o titulo do programa
            Cabeçalho();

            // Solicita o nome para o usuario - E verifica se ele escreveu algo
            do
            {
                Console.Write("Entre com seu nome: ");
                nome = Console.ReadLine();
                if (nome == "")
                {
                    Console.WriteLine("Nada digitado!");
                }
            } while (nome == "");
            Console.WriteLine();

            // Solicita a idade para o usuario - E verifica se a idade e maior que 0 e se é um inteiro
            do
            {
                Console.Write("Entre com sua idade: ");
                validaIdade = int.TryParse(Console.ReadLine(), out idade);
                if (validaIdade == false || idade <= 0)
                {
                    Console.WriteLine("Idade invalida");
                }

            } while (validaIdade == false || idade <= 0);
            Console.WriteLine();

            // Solicita a altura do usuario 
            do
            {
                Console.Write("Entre com sua altura(Em METROS): ");
                validaAltura = double.TryParse(Console.ReadLine()
                                                      .Replace(".", ",") // Metodo para trocar a virgula(,) pelo ponto final(.).
                                                      .ToString(CultureInfo.GetCultureInfo("pt-br")), out altura); // Força o idioma do programa para pt-br.
                if (altura <= 0)
                {
                    Console.WriteLine("Altura incorreta");
                }
            } while (altura <= 0);
            Console.WriteLine();

        }
        public static void Decora(string sinal) // função com uma laço de repetição for para apresentar algum caracter para decorar
        {
            for (int i = 0; i < 20; i++)
            {
                Console.Write("=");
            }
        }
        public static void Cabeçalho() // titulo do programa
        {
            Console.Write("\t");
            Decora("=");
            Console.Write("\t Diagnóstico Prévio \t");
            Decora("=");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}