//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;

//namespace Perlink.Oi.Juridico.SemNamespace
//{
//    public static class EnumHelpers
//    {
//        public static T ParseOrDefault<T>(string value, T defaultValue) where T : struct
//        {
//            if (Enum.TryParse<T>(value, true, out T result))
//            {
//                return result;
//            }
//            return defaultValue;
//        }
//    }

//    // TODO: Namespace (Somewhere to belong)
//    public class PaginatedQueryResult<T>
//    {
//        public IReadOnlyCollection<T> Data { get; set; }
//        public int Total { get; set; }
//    }
//    public class Pagination
//    {
//        public static int PagesToSkip(int quantidade, int total, int pagina)
//        {
//            var quantidadePaginas = Math.Ceiling((decimal)total / quantidade);

//            var paginasParaPular = quantidadePaginas >= pagina ? pagina - 1 : (int)quantidadePaginas - 1;

//            return paginasParaPular * quantidade;
//        }

//    }

//    public static class QueryableExtensions
//    {
//        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool conditional)
//        {
//            if (conditional)
//            {
//                return source.Where(predicate);
//            }

//            return source;
//        }

//        public static IQueryable<T> WhereIfNotNull<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, object? value)
//        {
//            if (value is null)
//            {
//                return source;
//            }

//            return source.Where(predicate);
//        }

//        public static ISorteredQueryable<TSource> SortBy<TSource, Tkey>(this IQueryable<TSource> source, Expression<Func<TSource, Tkey>> keySelector, bool ascending)
//        {
//            if (ascending)
//            {
//                return new SorteredQueryable<TSource>(source.OrderBy(keySelector));
//            }

//            return new SorteredQueryable<TSource>(source.OrderByDescending(keySelector));
//        }
//    }

//    /// <summary>
//    /// Enables the efficient, dynamic composition of query predicates.
//    /// </summary>
//    public static class PredicateBuilder
//    {
//        /// <summary>
//        /// Creates a predicate that evaluates to true.
//        /// </summary>
//        public static Expression<Func<T, bool>> True<T>() { return param => true; }

//        /// <summary>
//        /// Creates a predicate that evaluates to false.
//        /// </summary>
//        public static Expression<Func<T, bool>> False<T>() { return param => false; }

//        /// <summary>
//        /// Creates a predicate expression from the specified lambda expression.
//        /// </summary>
//        public static Expression<Func<T, bool>> Create<T>(Expression<Func<T, bool>> predicate) { return predicate; }

//        /// <summary>
//        /// Combines the first predicate with the second using the logical "and".
//        /// </summary>
//        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
//        {
//            return first.Compose(second, Expression.AndAlso);
//        }

//        /// <summary>
//        /// Combines the first predicate with the second using the logical "or".
//        /// </summary>
//        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
//        {
//            return first.Compose(second, Expression.OrElse);
//        }

//        /// <summary>
//        /// Negates the predicate.
//        /// </summary>
//        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
//        {
//            var negated = Expression.Not(expression.Body);
//            return Expression.Lambda<Func<T, bool>>(negated, expression.Parameters);
//        }

//        /// <summary>
//        /// Combines the first expression with the second using the specified merge function.
//        /// </summary>
//        private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
//        {
//            // zip parameters (map from parameters of second to parameters of first)
//            var map = first.Parameters
//                .Select((f, i) => new { f, s = second.Parameters[i] })
//                .ToDictionary(p => p.s, p => p.f);

//            // replace parameters in the second lambda expression with the parameters in the first
//            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

//            // create a merged lambda expression with parameters from the first expression
//            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
//        }

//        private class ParameterRebinder : ExpressionVisitor
//        {
//            private readonly Dictionary<ParameterExpression, ParameterExpression> map;

//            private ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
//            {
//                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
//            }

//            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
//            {
//                return new ParameterRebinder(map).Visit(exp);
//            }

//            protected override Expression VisitParameter(ParameterExpression p)
//            {
//                if (map.TryGetValue(p, out ParameterExpression replacement))
//                {
//                    p = replacement;
//                }

//                return base.VisitParameter(p);
//            }
//        }
//    }

//    public static class Logs
//    {
//        public static string PermissaoNegada(string permissao, string usuario) =>
//            string.Format("Permissão '{0}' negada para '{1}'", permissao, usuario);

//        public static string IniciandoOperacao(string operacao) =>
//            string.Format("Iniciando '{0}'", operacao);

//        public static string OperacaoFinalizada(string operacao) =>
//            string.Format("Operação '{0}' Finalizada", operacao);

//        public static string OperacaoComErro(string operacao) =>
//            string.Format("Operação '{0}' com Erro", operacao);

//        public static string Obtendo(string entidade) =>
//            string.Format("Obtendo '{0}'", entidade);

//        public static string Retornando(string entidade) =>
//            string.Format("Retornando '{0}'", entidade);

//        public static string ComandoInvalido(string command) =>
//            string.Format("Comando inválido '{0}'", command);

//        public static string ObtendoEntidade(string entity, int id) =>
//            ObtendoEntidade(entity, id.ToString());

//        public static string ObtendoEntidade(string entity, string id) =>
//            string.Format("Obtendo entidade '{0}:{1}'", entity, id);

//        public static string EntidadeNaoEncontrada(string entity, int id) =>
//            EntidadeNaoEncontrada(entity, id.ToString());

//        public static string EntidadeNaoEncontrada(string entity, string id) =>
//            string.Format("Entidade '{0}:{1}' não encontrada", entity, id);

//        public static string CriandoEntidade(string entity) =>
//            string.Format("Criando entidade '{0}'", entity);

//        public static string AtualizandoEntidade(string entity, int id) =>
//            AtualizandoEntidade(entity, id.ToString());

//        public static string AtualizandoEntidade(string entity, string id) =>
//            string.Format("Atualizando entidade '{0}:{1}'", entity, id);

//        public static string RemovendoEntidade(string entity, int id) =>
//            RemovendoEntidade(entity, id.ToString());

//        public static string RemovendoEntidade(string entity, string id) =>
//            string.Format("Removendo entidade '{0}:{1}'", entity, id);

//        public static string EntidadeInvalida(string entity) =>
//            string.Format("Entidade inválida '{0}'", entity);

//        public static string SalvandoEntidade(string entity) =>
//            string.Format("Salvando entidade '{0}'", entity);
//    }
//}



//Extensão para o Linq que testa condição para incluir ou não na query

//public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
//{
//    var query = Context.Set<T>()
//        .Include(Context.GetIncludePaths(typeof(T));
//    if (predicate != null)
//        query = query.Where(predicate);
//    return await query.ToListAsync();
//}