using System;

namespace Smartgym.Auxiliares
{
    public class Geradores
    {
        public int countMatricula;

        public string GerarMatricula(string Nome, DateTime DataNascimento)
        {
            var sampleNome = Nome.Substring(0, Nome.Length - 1) + "" + Nome.Substring(Nome.Length - 1, Nome.Length - 2);
            var sampleDate = DataNascimento.Year.ToString().Substring(2, Nome.Length - 2);
            var sampleCount = countMatricula++;

            var matricula = String.Format("SG{0}{1}{2}", sampleNome, sampleDate, sampleCount);

            return matricula;
        }
    }
}
