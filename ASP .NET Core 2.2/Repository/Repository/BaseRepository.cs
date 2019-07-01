using Domain.Repository;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly SmartgymContext SmartgymContext;

        public BaseRepository(SmartgymContext smartgymContext)
        {
            SmartgymContext = smartgymContext;
        }

        public void Incluid(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);
            SmartgymContext.SaveChanges();
        }

        public void IncluidWithoutSave(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);
        }

        public TEntity IncluidAndReturnEntity(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);
            SmartgymContext.SaveChanges();

            return entity;
        }

        public TEntity IncluidWithoutSaveAndReturnEntity(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Add(entity);

            return entity;
        }

        public void Update(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Update(entity);
            SmartgymContext.SaveChanges();
        }

        public TEntity UpdateAndReturnEntity(TEntity entity)
        {
            SmartgymContext.Set<TEntity>().Update(entity);
            SmartgymContext.SaveChanges();

            return entity;
        }

        public void Remove(TEntity entity)
        {
            SmartgymContext.Remove(entity);
            SmartgymContext.SaveChanges();
        }

        public long[] Logar(Domain.DTO.Conta contaDTO)
        {
            long[] data = { 0, 0 };

            try
            {
                var conta = SmartgymContext.Conta.Where(x => x.EmailConta == contaDTO.EmailConta);

                if (conta.First().SenhaConta == contaDTO.SenhaConta)
                {
                    var entityAlu = SmartgymContext.Aluno.Where(x => x.IdContaAluno == conta.First().IdConta);
                    try
                    {
                        data[0] = entityAlu.First().IdAluno;
                        data[1] = entityAlu.First().PermissaoAluno;

                        return data;
                    }
                    catch
                    {
                        var entityProf = SmartgymContext.Professor.Where(x => x.IdContaProfessor == conta.First().IdConta);

                        data[0] = entityProf.First().IdProfessor;
                        data[1] = entityProf.First().PermissaoProfessor;

                        return data;
                    }
                }
                else
                {
                    data[0] = -1;

                    return data;
                }
            }
            catch
            {
                data[0] = 0;

                return data;
            }
        }

        public long VerifyEmail(Domain.DTO.Conta contaDTO)
        {
            try
            {
                var conta = SmartgymContext.Conta.Where(x => x.EmailConta == contaDTO.EmailConta);

                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return SmartgymContext.Set<TEntity>().ToList();
        }

        public TEntity GetbyId(long Id)
        {
            return SmartgymContext.Set<TEntity>().Find(Id);
        }

        public void SaveChanges()
        {
            SmartgymContext.SaveChanges();
        }

        public void Dispose()
        {
            SmartgymContext.Dispose();
        }
    }
}