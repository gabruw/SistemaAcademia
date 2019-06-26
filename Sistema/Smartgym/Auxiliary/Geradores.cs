using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Auxiliary
{
    public class Geradores
    {
        public string GerarMatricula(string nomeCompleto)
        {
            var sampleNome = nomeCompleto.Substring(0, nomeCompleto.Length - nomeCompleto.Length + 1);
            var sample3Mili = DateTime.Now.Millisecond.ToString();
            var Sample1Mili = DateTime.Now.Millisecond.ToString().Substring(0, sample3Mili.Length - 1);

            while (sample3Mili.Length != 3)
            {
                sample3Mili = DateTime.Now.Millisecond.ToString();
            }

            while (Sample1Mili.Length != 1)
            {
                Sample1Mili = DateTime.Now.Millisecond.ToString().Substring(0, sample3Mili.Length - 2);
            }

            var matricula = String.Format("SG{0}{1}{2}", sampleNome, sample3Mili, Sample1Mili);

            return matricula;
        }

        public int GerarIdade(DateTime dataNascimento)
        {
            var dataAtual = DateTime.Now;

            var idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento > dataAtual.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

        public double CalcularIMC(DateTime dataNascimento, Domain.DTO.Avaliacao avaliacaoDTO, int sexo, out double percentualGordura)
        {
            var idade = this.GerarIdade(dataNascimento);

            var soma7 = avaliacaoDTO.DobraCutaneaAbdomemAvaliacao + avaliacaoDTO.DobraCutaneaCoxaAvaliacao +
                   avaliacaoDTO.DobraCutaneaPanturrilhaAvaliacao + avaliacaoDTO.DobraCutaneaPeitoAvaliacao +
                   avaliacaoDTO.DobraCutaneaQuadrilAvaliacao + avaliacaoDTO.DobraCutaneaTricepsAvaliacao;

            double densidadeCorporal = 0;
            if (sexo == 1)
            {
                densidadeCorporal = 1.112 - 0.00043499 * soma7 + 0.00000055 * (soma7 * soma7) - 0.00028826 * idade;
            }
            else
            {
                densidadeCorporal = 1.0970 - 0.000464971 * soma7 + 0.00000056 * (soma7 * soma7) - 0.00012828 * idade;
            }

            percentualGordura = ((4.95 / densidadeCorporal) - 4.50) * 100;
            var Imc = avaliacaoDTO.PesoAvaliacao / (avaliacaoDTO.AlturaAvaliacao * avaliacaoDTO.AlturaAvaliacao);

            return Imc;
        }

        public int EraseEspecialAndReturnInt(string data)
        {
            var result = Regex.Replace(data, "[^0-9a-zA-Z]+", "").ToString();
            var resultInt = Int32.Parse(result);

            return resultInt;
        }

        public long EraseEspecialAndReturnLong(string data)
        {
            var result = Regex.Replace(data, "[^0-9a-zA-Z]+", "").ToString();
            var resultInt = Int64.Parse(result);

            return resultInt;
        }

        public string GetFileName(string nomeCompleto, string ext)
        {
            return String.Format("{0}{1}{2}.{3}", nomeCompleto, DateTime.Now.Millisecond.ToString(), DateTime.Now.Second.ToString(), ext); ;
        }

        public string GetImageToBase64(IFormCollection image)
        {
            var img64 = string.Empty;

            using (var stream = new MemoryStream())
            {
                image.Files[0].CopyToAsync(stream);

                img64 = Convert.ToBase64String(stream.ToArray());
            }

            return img64;
        }
    }
}