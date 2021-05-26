using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaCheque.Cheques
{
    public class Cheque
    {
        private double valor;
        private string valor_extenso;

        public string Valor_extenso { get => valor_extenso; }

        public string ChequePorExtrnso(double valor)
        {
            this.valor = valor;
            this.valor_extenso = PreencherCheque(valor);
            return Valor_extenso;
        }

        public string PreencherCheque(double valor)
        {
            int valor_divisao = 0;
            string str_valor = null, str_centavo = null;
            double resto;
            double valor_restante = valor;

            List<double> lista_valores = new List<double>();

            while (valor_restante != 0)
            {
                if (valor_restante < 1)
                {
                    valor_restante = valor_restante * 100;
                    valor_divisao = 10;
                    str_centavo = "centavo";
                }
                else if (valor_restante >= 1)
                {
                    valor_divisao = 1;
                    if (str_valor.Equals(null))
                        str_valor = "unidade";
                }
                else if (valor_restante >= 10)
                {
                    valor_divisao = 10;
                    if (str_valor.Equals(null))
                        str_valor = "desena";
                }
                else if (valor_restante >= 100)
                {
                    valor_divisao = 100;
                    if (str_valor.Equals(null))
                        str_valor = "centena";
                }
                else if (valor_restante >= 1000)
                {
                    valor_divisao = 1000;
                    if (str_valor.Equals(null))
                        str_valor = "milhar";
                }
                else if (valor_restante >= 1000000)
                {
                    valor_divisao = 1000000;
                    if (str_valor.Equals(null))
                        str_valor = "milhão";
                }
                else if (valor_restante >= 1000000000)
                {
                    valor_divisao = 1000000000;
                    if (str_valor.Equals(null))
                        str_valor = "bilhão";
                }

                resto = valor_restante % valor_divisao;

                lista_valores.Add(valor_restante - resto);

                valor_restante = resto;
            }

            string valor_extenso = ValorExtenso(lista_valores, str_valor, str_centavo);

            Console.WriteLine(valor_extenso);
            Console.ReadLine();

            return valor_extenso;
        }

        private string ValorExtenso(List<double> lista_valores, string str_valor, string str_centavo)
        {
            string valor_extenso = null;
            int tamanho_lista = lista_valores.Count(), cont = 0;

            if (str_centavo.Equals(null))
            {
                foreach (var valor in lista_valores)
                {
                    if (valor < 10)
                        valor_extenso = Unidades(valor) + " " + DicionarioValor(valor, str_valor);
                    else if (valor < 100)
                        valor_extenso = Dezenas(valor) + " " + DicionarioValor(valor, str_valor);
                    else if (valor < 1000)
                        valor_extenso = Centenas(valor) + " " + DicionarioValor(valor, str_valor);

                    if (tamanho_lista > 1 && cont < tamanho_lista)
                        valor_extenso = " e ";
                    cont++;
                }
            }
            else if (!str_centavo.Equals(null))
            {
                foreach (var valor in lista_valores)
                {
                    if (cont == tamanho_lista)
                    {
                        if (valor < 10)
                            valor_extenso = Unidades(valor) + " " + DicionarioValor(valor, str_centavo);
                        else if (valor < 100)
                            valor_extenso = Dezenas(valor) + " " + DicionarioValor(valor, str_centavo);
                    }

                    if (valor < 10)
                        valor_extenso = Unidades(valor) + " " + DicionarioValor(valor, str_valor);
                    else if (valor < 100)
                        valor_extenso = Dezenas(valor) + " " + DicionarioValor(valor, str_valor);
                    else if (valor < 1000)
                        valor_extenso = Centenas(valor) + " " + DicionarioValor(valor, str_valor);

                    if (tamanho_lista > 1 && cont < tamanho_lista)
                        valor_extenso = " e ";

                    cont++;
                }
            }
            return valor_extenso;
        }

        private string DicionarioValor(double valor, string str_valor)
        {
            string valor_extenso = "";
            switch (str_valor)
            {
                case "centavo":
                    if (valor == 1)
                        valor_extenso = "centavo de real";
                    else
                        valor_extenso = "centavos de real";
                    break;
                case "unidade":
                    if (valor == 1)
                        valor_extenso = "real";
                    else
                        valor_extenso = "reais";
                    break;
                case "dezena":
                    valor_extenso = "reais";
                    break;
                case "centena":
                    valor_extenso = "reais";
                    break;
                case "milhar":
                    valor_extenso = "reais";
                    break;
                case "milhão":
                    if (valor == 1)
                        valor_extenso = "milhão de reais";
                    else
                        valor_extenso = "milhões de reais";
                    break;
                case "bilhão":
                    if (valor == 1)
                        valor_extenso = "bilhão de reais";
                    else
                        valor_extenso = "bilhões de reais";
                    break;
            }

            return valor_extenso;
        }

        public string Unidades(double valor)
        {
            string unidade_extenso = "";
            switch (valor)
            {
                case 1:
                    unidade_extenso = "um";
                    break;
                case 2:
                    unidade_extenso = "dois";
                    break;
                case 3:
                    unidade_extenso = "três";
                    break;
                case 4:
                    unidade_extenso = "quatro";
                    break;
                case 5:
                    unidade_extenso = "cinco";
                    break;
                case 6:
                    unidade_extenso = "seis";
                    break;
                case 7:
                    unidade_extenso = "sete";
                    break;
                case 8:
                    unidade_extenso = "oito";
                    break;
                case 9:
                    unidade_extenso = "nove";
                    break;
            }

            return unidade_extenso;
        }

        public string Dezenas(double valor)
        {
            string dezena_extenso = "";
            switch (valor)
            {
                case 10:
                    dezena_extenso = "dez";
                    break;
                case 11:
                    dezena_extenso = "onze";
                    break;
                case 12:
                    dezena_extenso = "doze";
                    break;
                case 13:
                    dezena_extenso = "treze";
                    break;
                case 14:
                    dezena_extenso = "quatorze";
                    break;
                case 15:
                    dezena_extenso = "quinze";
                    break;
                case 16:
                    dezena_extenso = "dezesseis";
                    break;
                case 17:
                    dezena_extenso = "dezessete";
                    break;
                case 18:
                    dezena_extenso = "dezoito";
                    break;
                case 19:
                    dezena_extenso = "dezenove";
                    break;
                case 20:
                    dezena_extenso = "vinte";
                    break;
                case 30:
                    dezena_extenso = "trinta";
                    break;
                case 40:
                    dezena_extenso = "quarenta";
                    break;
                case 50:
                    dezena_extenso = "cinquenta";
                    break;
                case 60:
                    dezena_extenso = "sessenta";
                    break;
                case 70:
                    dezena_extenso = "setenta";
                    break;
                case 80:
                    dezena_extenso = "oitenta";
                    break;
                case 90:
                    dezena_extenso = "noventa";
                    break;
            }

            return dezena_extenso;
        }

        public string Centenas(double valor)
        {
            string centena_extenso = "";
            switch (valor)
            {
                case 100:
                    centena_extenso = "cem";
                    break;
                case 200:
                    centena_extenso = "duzentos";
                    break;
                case 300:
                    centena_extenso = "trezentos";
                    break;
                case 400:
                    centena_extenso = "quatrocentos";
                    break;
                case 500:
                    centena_extenso = "quinhentos";
                    break;
                case 600:
                    centena_extenso = "seiscentos";
                    break;
                case 700:
                    centena_extenso = "setecentos";
                    break;
                case 800:
                    centena_extenso = "oitocentos";
                    break;
                case 900:
                    centena_extenso = "novecentos";
                    break;
            }

            return centena_extenso;
        }
    }
}
