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