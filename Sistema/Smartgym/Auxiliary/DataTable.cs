using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Auxiliary
{
    public class DataTable
    {
        // Aluno
        private PropertyInfo getAlunoProperty(string name)
        {
            PropertyInfo prop = null;

            var properties = typeof(Domain.DTO.Aluno).GetProperties();

            foreach(var aluno in properties)
            {
                if (aluno.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = aluno;
                    break;
                }
            }

            return prop;
        }

        public IEnumerable<Domain.DTO.Aluno> AlunoDataProcessForm(IEnumerable<Domain.DTO.Aluno> listAlunosDTO, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if(requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };

                if(requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columnName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if(pageSize > 0)
                    {
                        var prop = getAlunoProperty(columnName);
                        if(sortDirection == "asc")
                        {
                            return listAlunosDTO.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                        {
                            return listAlunosDTO.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                    }
                    else
                    {
                        return listAlunosDTO;
                    }
                }
            }

            return null;
        }

        // Professor
        private PropertyInfo getProfessorProperty(string name)
        {
            PropertyInfo prop = null;

            var properties = typeof(Domain.DTO.Professor).GetProperties();

            foreach (var professor in properties)
            {
                if (professor.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = professor;
                    break;
                }
            }

            return prop;
        }

        public IEnumerable<Domain.DTO.Professor> ProfessorDataProcessForm(IEnumerable<Domain.DTO.Professor> listProfessorsDTO, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };

                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columnName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getProfessorProperty(columnName);
                        if (sortDirection == "asc")
                        {
                            return listProfessorsDTO.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                        {
                            return listProfessorsDTO.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                    }
                    else
                    {
                        return listProfessorsDTO;
                    }
                }
            }

            return null;
        }

        // Unidade
        private PropertyInfo getUnidadeProperty(string name)
        {
            PropertyInfo prop = null;

            var properties = typeof(Domain.DTO.Unidade).GetProperties();

            foreach (var unidades in properties)
            {
                if (unidades.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = unidades;
                    break;
                }
            }

            return prop;
        }

        public IEnumerable<Domain.DTO.Unidade> UnidadeDataProcessForm(IEnumerable<Domain.DTO.Unidade> listUnidadesDTO, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };

                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columnName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getUnidadeProperty(columnName);
                        if (sortDirection == "asc")
                        {
                            return listUnidadesDTO.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                        {
                            return listUnidadesDTO.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                    }
                    else
                    {
                        return listUnidadesDTO;
                    }
                }
            }

            return null;
        }

        // Aparelho
        private PropertyInfo getAparelhoProperty(string name)
        {
            PropertyInfo prop = null;

            var properties = typeof(Domain.DTO.Aparelho).GetProperties();

            foreach (var aparelhos in properties)
            {
                if (aparelhos.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = aparelhos;
                    break;
                }
            }

            return prop;
        }

        public IEnumerable<Domain.DTO.Aparelho> AparelhoDataProcessForm(IEnumerable<Domain.DTO.Aparelho> listAparelhosDTO, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };

                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columnName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getAparelhoProperty(columnName);
                        if (sortDirection == "asc")
                        {
                            return listAparelhosDTO.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                        {
                            return listAparelhosDTO.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                    }
                    else
                    {
                        return listAparelhosDTO;
                    }
                }
            }

            return null;
        }

        // Ficha
        private PropertyInfo getFichaProperty(string name)
        {
            PropertyInfo prop = null;

            var properties = typeof(Domain.DTO.Ficha).GetProperties();

            foreach (var ficha in properties)
            {
                if (ficha.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = ficha;
                    break;
                }
            }

            return prop;
        }

        public IEnumerable<Domain.DTO.Ficha> FichaDataProcessForm(IEnumerable<Domain.DTO.Ficha> listFichasDTO, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };

                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columnName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getFichaProperty(columnName);
                        if (sortDirection == "asc")
                        {
                            return listFichasDTO.OrderBy(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                        else
                        {
                            return listFichasDTO.OrderByDescending(prop.GetValue).Skip(skip).Take(pageSize).ToList();
                        }
                    }
                    else
                    {
                        return listFichasDTO;
                    }
                }
            }

            return null;
        }
    }
}