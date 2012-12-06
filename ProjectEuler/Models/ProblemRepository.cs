using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ProjectEuler.Models
{ 
    public class ProblemRepository : IProblemRepository
    {
        ProjectEulerContext context = new ProjectEulerContext();

        public IQueryable<Problem> All
        {
            get { return context.Problems; }
        }

        public IQueryable<Problem> AllIncluding(params Expression<Func<Problem, object>>[] includeProperties)
        {
            IQueryable<Problem> query = context.Problems;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Problem Find(int id)
        {
            return context.Problems.Find(id);
        }

        public void InsertOrUpdate(Problem problem)
        {
            if (problem.ProblemId == default(int)) {
                // New entity
                context.Problems.Add(problem);
            } else {
                // Existing entity
                context.Entry(problem).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var problem = context.Problems.Find(id);
            context.Problems.Remove(problem);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IProblemRepository : IDisposable
    {
        IQueryable<Problem> All { get; }
        IQueryable<Problem> AllIncluding(params Expression<Func<Problem, object>>[] includeProperties);
        Problem Find(int id);
        void InsertOrUpdate(Problem problem);
        void Delete(int id);
        void Save();
    }
}